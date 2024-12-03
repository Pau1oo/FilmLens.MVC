﻿using FilmLens.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using StackExchange.Redis;

namespace FilmLens.AppServices.Authentication.Services
{
	/// <summary>
	/// Сервис аутентификации.
	/// </summary>
	public sealed class AuthenticationService : IAuthenticationService
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly IHttpContextAccessor _httpContextAccessor;

		/// <inheritdoc/>
		public AuthenticationService(
			SignInManager<User> signInManager,
			UserManager<User> userManager,
			IHttpContextAccessor httpContextAccessor)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_httpContextAccessor = httpContextAccessor;
		}

		/// <inheritdoc/>
		public async Task<IdentityResult> RegisterAsync(string name, string email, string password, CancellationToken cancellation)
		{
			if (await _userManager.FindByEmailAsync(email) != null)
			{
				return IdentityResult.Failed(new IdentityError
				{
					Code = "DuplicateEmail",
					Description = "Пользователь с таким email уже существует."
				});
			}

			var user = new User
			{
				UserName = name,
				Email = email,
				CreatedAt = DateTime.UtcNow,
				ReviewCount = 0
			};

			var result = await _userManager.CreateAsync(user, password);

			var addRoleResult = await _userManager.AddToRoleAsync(user, "User");
			if (!addRoleResult.Succeeded)
			{
				await _userManager.DeleteAsync(user);
				return addRoleResult;
			}

			return IdentityResult.Success;
		}

		/// <inheritdoc/>
		public async Task<bool> SignInAsync(string email, string password, CancellationToken cancellation)
		{
			var user = await _userManager.FindByEmailAsync(email);
				//?? throw new UnauthorizedAccessException("Неправильный email или пароль.");

			var isPasswordMatched = await _userManager.CheckPasswordAsync(user, password);
			if (isPasswordMatched)
			{
				await _signInManager.SignInAsync(user, isPersistent: true);
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <inheritdoc/>
		public Task SignOutAsync(CancellationToken cancellation)
		{
			return _signInManager.SignOutAsync();
		}
	}
}

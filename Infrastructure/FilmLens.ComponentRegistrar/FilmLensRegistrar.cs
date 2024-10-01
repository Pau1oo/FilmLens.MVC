using AutoMapper;
using FilmLens.AppServices.Authentication.Services;
using FilmLens.AppServices.Common.CacheService;
using FilmLens.AppServices.Common.Redis;
using FilmLens.AppServices.Common.TMDb;
using FilmLens.DataAccess.Common;
using FilmLens.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;

namespace FilmLens.ComponentRegistrar
{
	/// <summary>
	/// Класс регистрации компонентов приложения.
	/// </summary>
	public static class FilmLensRegistrar
	{
		public static void AddComponents(IServiceCollection services, IConfiguration configuration)
		{
			services.AddIdentity<User, Role>()
				.AddEntityFrameworkStores<MutableFilmLensDbContext>()
				.AddDefaultTokenProviders();

			RegisterRepositories(services, configuration);
			RegisterServices(services, configuration);
		//	RegisterMapper(services);
		}

		private static void RegisterRepositories(IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<MutableFilmLensDbContext>(options =>
				options.UseNpgsql(connectionString)
			);
			services.AddDbContext<ReadonlyFilmLensDbContext>(options =>
				options.UseNpgsql(connectionString)
			);
		}

		private static void RegisterServices(IServiceCollection services, IConfiguration configuration)
		{
			var redisConfiguration = configuration
				.GetSection("Redis")
				.Get<RedisConfiguration>();

			services.AddStackExchangeRedisExtensions<NewtonsoftSerializer>(redisConfiguration);

			services.AddScoped<IAuthenticationService, AuthenticationService>();

			services.AddScoped<ITmdbService, TmdbService>();

			services.AddSingleton<IRedisCache, RedisCache>();
			services.AddSingleton<ICacheService, RedisCacheService>();
		}

		/*private static void RegisterMapper(IServiceCollection services)
		{
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new ProductAttributeMappingProfile());
			});

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);
		}*/
	}
}

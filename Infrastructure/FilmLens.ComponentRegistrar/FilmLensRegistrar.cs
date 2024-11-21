using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using FilmLens.AppServices.Authentication.Services;
using FilmLens.AppServices.Common.CacheService;
using FilmLens.AppServices.Common.Redis;
using FilmLens.AppServices.Common.TMDb;
using FilmLens.DataAccess.Common;
using FilmLens.Domain.Entities;
using FilmLens.Infrastructure.JwtGenerator;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FilmLens.DataAccess.Middlewares;
using Microsoft.AspNetCore.Builder;
using FilmLens.AppServices.Common.Events.Common;
using FilmLens.DataAccess.Events;
using Hangfire;
using Hangfire.PostgreSql;
using FilmLens.Infrastructure.Mappings;
using FilmLens.AppServices.Movies.Services;
using FilmLens.AppServices.Movies.Repositories;
using FilmLens.DataAccess.Movies.Repositories;
using FilmLens.AppServices.Genres.Repositories;
using FilmLens.DataAccess.Genres.Repositories;
using FilmLens.AppServices.MovieGenres.Repositories;
using FilmLens.DataAccess.MovieGenres.Repositories;

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
				.AddRoles<Role>()
				.AddDefaultTokenProviders();

			services.AddHttpClient<ITmdbService, TmdbService>();

			var jwtOptions = configuration.GetSection("JwtOptions").Get<JwtOptions>();
			services.AddAuthentication()
				.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = jwtOptions.Issuer,
						ValidAudience = jwtOptions.Audience,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
					};
				});

			RegisterRepositories(services, configuration);
			RegisterServices(services, configuration);
			RegisterMapper(services);
			RegisterScheduler(services, configuration);
			RegisterOptions(services, configuration);
		}

		public static void RegisterMiddlewares(WebApplication app)
		{
			app.UseMiddleware<TransactionMiddleware>();
		}

		private static void RegisterOptions(IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
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

			services.AddScoped<IMovieRepository, MovieRepository>();
			services.AddScoped<IGenreRepository, GenreRepository>();
			services.AddScoped<IMovieGenresRepository, MovieGenresRepository>();
		}

		private static void RegisterServices(IServiceCollection services, IConfiguration configuration)
		{
			var redisConfiguration = configuration
				.GetSection("Redis")
				.Get<RedisConfiguration>();

			services.AddStackExchangeRedisExtensions<NewtonsoftSerializer>(redisConfiguration);

			services.AddScoped<IAuthenticationService, AuthenticationService>();
			services.AddScoped<ITmdbService, TmdbService>();
			services.AddScoped<IMovieService, MovieService>();

			services.AddSingleton<IRedisCache, RedisCache>();
			services.AddSingleton<ICacheService, RedisCacheService>();
			services.AddSingleton<IJwtGenerator, JwtGenerator>();

			services.AddScoped<IEventDispatcher, EventDispatcher>();
			services.AddScoped<IEventAccumulator, EventAccumulator>();
		}

		private static void RegisterMapper(IServiceCollection services)
		{
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MovieMappingProfile());
				mc.AddProfile(new GenreMappingProfile());
				mc.AddProfile(new ReviewMappingProfile());
				mc.AddProfile(new MovieGenreMappingProfile());
			});

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);
		}

		private static void RegisterScheduler(IServiceCollection services, IConfiguration configuration)
		{
			services.AddHangfire(conf =>
				conf.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
				.UseSimpleAssemblyNameTypeSerializer()
				.UseRecommendedSerializerSettings()
				.UsePostgreSqlStorage(options =>
				{
					options.UseNpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
				})
			);

			services.AddHangfireServer();
		}
	}
}

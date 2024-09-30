using AutoMapper;
using FilmLens.AppServices.Common.CacheService;
using FilmLens.AppServices.Common.Redis;
using FilmLens.DataAccess.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;

namespace FilmLens.ComponentRegistrar
{
	public static class FilmLensRegistrar
	{
		public static void AddComponents(IServiceCollection services, IConfiguration configuration)
		{
			RegisterRepositories(services, configuration);
			RegisterServices(services, configuration);
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

			services.AddSingleton<IRedisCache, RedisCache>();
			services.AddSingleton<ICacheService, RedisCacheService>();
		}
	}
}

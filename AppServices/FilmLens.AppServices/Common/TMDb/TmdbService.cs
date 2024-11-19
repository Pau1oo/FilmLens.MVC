using FilmLens.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FilmLens.AppServices.Common.TMDb
{
	/// <summary>
	/// Сервис для взаимодействия с TMDb API, который предоставляет информацию о фильмах.
	/// </summary>
	public sealed class TmdbService : ITmdbService
	{
		private readonly HttpClient _httpClient;
		private readonly string _apiKey;

		public TmdbService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_apiKey = configuration["TMDb:ApiKey"];
		}

		/// <inheritdoc/>
		public async Task<Movie> GetMovieDetails(int movieId)
		{
			var url = $"https://api.themoviedb.org/3/movie/{movieId}?api_key={_apiKey}&language=ru";
			var response = await _httpClient.GetStringAsync(url);
			return JsonConvert.DeserializeObject<Movie>(response);
		}

		/// <inheritdoc/>
		public async Task<MovieSearchResults> SearchMovies(string query)
		{
			var url = $"https://api.themoviedb.org/3/search/movie?api_key={_apiKey}&query={query}&language=ru";
			var response = await _httpClient.GetStringAsync(url);
			var searchResults = JsonConvert.DeserializeObject<MovieSearchResults>(response);
			return searchResults;
		}
	}
}

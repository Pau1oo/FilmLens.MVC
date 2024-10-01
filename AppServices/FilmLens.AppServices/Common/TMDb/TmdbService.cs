using FilmLens.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLens.AppServices.Common.TMDb
{
	/// <summary>
	/// Сервис для взаимодействия с TMDb API, который предоставляет информацию о фильмах.
	/// </summary>
	public sealed class TmdbService : ITmdbService
	{
		private readonly HttpClient _httpClient;
		private readonly string _apiKey;

		public TmdbService(IConfiguration configuration)
		{
			_httpClient = new HttpClient();
			_apiKey = configuration["TMDb:ApiKey"];
		}

		/// <inheritdoc/>
		public async Task<Movie> GetMovieDetails(int movieId)
		{
			var url = $"https://api.themoviedb.org/3/movie/{movieId}?api_key={_apiKey}&language=en-US";
			var response = await _httpClient.GetStringAsync(url);
			var movieDetails = JsonConvert.DeserializeObject<Movie>(response);
			return movieDetails;
		}

		/// <inheritdoc/>
		public async Task<MovieSearchResults> SearchMovies(string query)
		{
			var url = $"https://api.themoviedb.org/3/search/movie?api_key={_apiKey}&query={query}&language=en-US";
			var response = await _httpClient.GetStringAsync(url);
			var searchResults = JsonConvert.DeserializeObject<MovieSearchResults>(response);
			return searchResults;
		}
	}
}

﻿using FilmLens.Contracts.Common;
using FilmLens.Contracts.Movies;

namespace FilmLens.AppServices.Movies.Services
{
	/// <summary>
	/// Интерфейс сервиса по работе с фильмами.
	/// </summary>
	public interface IMovieService
	{
		/// <summary>
		/// Возвращает список фильмов.
		/// </summary>
		/// <param name="request">Запрос на получение списка фильмов.</param>
		/// <param name="cancellationToken">Токен отмены операциию</param>
		/// <returns></returns>
		Task<MoviesListDto> GetMoviesAsync(PagedRequest request, CancellationToken cancellationToken);

		/// <summary>
		/// Добавляет фильм.
		/// </summary>
		/// <param name="movieDto">Транспортная модель фильма.</param>
		/// <param name="cancellationToken">Токер отмены операции.</param>
		/// <returns></returns>
		Task AddMovieAsync(MovieDto movieDto, CancellationToken cancellationToken);
	}
}
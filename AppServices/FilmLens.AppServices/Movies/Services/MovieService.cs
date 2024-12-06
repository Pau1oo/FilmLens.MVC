using AutoMapper;
using FilmLens.AppServices.Common.Events.Common;
using FilmLens.AppServices.Genres.Repositories;
using FilmLens.AppServices.Movies.Models;
using FilmLens.AppServices.Movies.Repositories;
using FilmLens.Contracts.Common;
using FilmLens.Contracts.Movies;
using FilmLens.Domain.Entities;

namespace FilmLens.AppServices.Movies.Services
{
	/// <summary>
	/// Сервис по работе с фильмами.
	/// </summary>
	public sealed class MovieService : IMovieService
	{
		private readonly IMovieRepository _movieRepository;
		private readonly IGenreRepository _genreRepository;
		private readonly IMapper _mapper;
		private readonly IEventAccumulator _eventContainer;

        public MovieService(
			IMovieRepository movieRepository,
			IGenreRepository genreRepository,
			IMapper mapper,
			IEventAccumulator eventAccumulator)
        {
            _movieRepository = movieRepository;
			_genreRepository = genreRepository;
			_mapper = mapper;
			_eventContainer = eventAccumulator;
        }

		public async Task AddMovieAsync(MovieDto movieDto, CancellationToken cancellationToken)
		{
			var movieEntity = _mapper.Map<Movie>(movieDto);
			movieEntity.Genres = new List<Genre>();

			var genreIds = movieDto.Genres.Select(g => g.Id).ToList();

			var existingGenres = await _genreRepository.GetGenresByIdsAsync(genreIds, cancellationToken);

			var newGenres = movieDto.Genres
				.Where(dtoGenre => existingGenres.All(dbGenre => dbGenre.Id != dtoGenre.Id))
				.Select(dtoGenre => new Genre { Id = dtoGenre.Id, Name = dtoGenre.Name })
				.ToList();

			var allGenres = existingGenres.Concat(newGenres).ToList();

			if (newGenres.Any())
			{
				movieEntity.Genres = newGenres;
				await _movieRepository.AddAsync(movieEntity, cancellationToken);
			}
			if (existingGenres.Any())
			{
				movieEntity.Genres = allGenres;
				await _movieRepository.UpdateAsync(movieEntity, cancellationToken);
			}
			
		}

		public async Task<MoviesListDto> GetMoviesAsync(PagedRequest request, CancellationToken cancellation)
		{
			if (request == null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			var totalCount = await _movieRepository.GetMoviesTotalCountAsync(request.GenreId, request.UserId, cancellation);

			if (totalCount == 0)
			{
				return new MoviesListDto
				{
					PageNumber = 1,
					TotalCount = totalCount,
					PageSize = 1,
					GenreName = request.GenreName,
					Result = []
				};
			}

			var movies = await _movieRepository.GetMoviesAsync(new GetMoviesRequest
			{
				Take = request.PageSize,
				Skip = (request.PageNumber - 1) * request.PageSize,
				GenreId = request.GenreId,
				GenreName = request.GenreName,
				UserId = request.UserId
			}, cancellation);

			var movieList = _mapper.Map<List<MovieDto>>(movies);

			return new MoviesListDto
			{
				PageNumber = request.PageNumber,
				PageSize = request.PageSize,
				TotalCount = totalCount,
				Result = movieList,
				UserId = request.UserId,
				GenreId = request.GenreId,
				GenreName = request.GenreName
			};
		}

		public async Task<MovieDto> GetMovieAsync(int movieId, CancellationToken cancellation)
		{
			var movieEntity = await _movieRepository.GetMovieAsync(movieId, cancellation);

			var movie = _mapper.Map<MovieDto>(movieEntity);

			return movie;
		}
	}
}

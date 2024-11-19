using AutoMapper;
using FilmLens.AppServices.Common.Events.Common;
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
		private readonly IMovieRepository _repository;
		private readonly IMapper _mapper;
		private readonly IEventAccumulator _eventContainer;

        public MovieService(
			IMovieRepository repository,
			IMapper mapper,
			IEventAccumulator eventAccumulator)
        {
            _repository = repository;
			_mapper = mapper;
			_eventContainer = eventAccumulator;
        }

		public async Task AddMovieAsync(MovieDto movieDto, CancellationToken cancellationToken)
		{
			var movieEntity = _mapper.Map<Movie>(movieDto);

			await _repository.AddAsync(movieEntity, cancellationToken);
		}

		public async Task<MoviesListDto> GetMoviesAsync(PagedRequest request, CancellationToken cancellation)
		{
			if (request == null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			var totalCount = await _repository.GetMoviesTotalCountAsync(cancellation);

			if (totalCount == 0)
			{
				return new MoviesListDto
				{
					PageNumber = 1,
					TotalCount = totalCount,
					PageSize = 1,
					Result = []
				};
			}

			var movies = await _repository.GetMoviesAsync(new GetMoviesRequest
			{
				Take = request.PageSize,
				Skip = (request.PageNumber - 1) * request.PageSize
			}, cancellation);

			var movieList = _mapper.Map<List<MovieDto>>(movies);

			return new MoviesListDto
			{
				PageNumber = request.PageNumber,
				PageSize = request.PageSize,
				TotalCount = totalCount,
				Result = movieList
			};
		}
	}
}

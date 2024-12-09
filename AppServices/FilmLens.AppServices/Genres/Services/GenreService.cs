using AutoMapper;
using FilmLens.AppServices.Genres.Repositories;
using FilmLens.Contracts.Genres;

namespace FilmLens.AppServices.Genres.Services
{
	/// <summary>
	/// Сервис по работе с жанрами.
	/// </summary>
	public sealed class GenreService : IGenreService
	{
		private readonly IGenreRepository _genreRepository;
		private readonly IMapper _mapper;
		
        public GenreService(IGenreRepository genreRepository, 
						    IMapper mapper)
        {
            _genreRepository = genreRepository;
			_mapper = mapper;
        }

		/// <inheritdoc/>
		public async Task<List<GenreDto>> GetGenresAsync(int movieId, CancellationToken cancellation)
		{
			var genres = await _genreRepository.GetGenresByMovieIdAsync(movieId, cancellation);

			var genresList = _mapper.Map<List<GenreDto>>(genres);

			return genresList;
		}
	}
}

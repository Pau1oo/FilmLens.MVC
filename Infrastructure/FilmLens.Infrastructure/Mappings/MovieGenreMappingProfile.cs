using AutoMapper;
using FilmLens.Contracts.MovieGenres;
using FilmLens.Domain.Entities;

namespace FilmLens.Infrastructure.Mappings
{
	public sealed class MovieGenreMappingProfile : Profile
	{
        public MovieGenreMappingProfile()
        {
			CreateMap<MovieGenre, MovieGenreDto>();
			CreateMap<MovieGenreDto, MovieGenre>();
		}
	}
}

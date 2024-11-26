using AutoMapper;
using FilmLens.Contracts.Genres;
using FilmLens.Contracts.Movies;
using FilmLens.Contracts.Reviews;
using FilmLens.Domain.Entities;

namespace FilmLens.Infrastructure.Mappings
{
	public sealed class MovieMappingProfile : Profile
	{
        public MovieMappingProfile()
        {
			CreateMap<Movie, MovieDto>()
			.ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres))
			.ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews));

			CreateMap<MovieDto, Movie>()
			.ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres))
			.ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews));
		}
    }
}

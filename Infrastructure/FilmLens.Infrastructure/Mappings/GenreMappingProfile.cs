using AutoMapper;
using FilmLens.Contracts.Genres;
using FilmLens.Contracts.Movies;
using FilmLens.Domain.Entities;

namespace FilmLens.Infrastructure.Mappings
{
	public sealed class GenreMappingProfile : Profile
	{
        public GenreMappingProfile()
        {
            CreateMap<Genre, GenreDto>()
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies));

			CreateMap<GenreDto, Genre>()
				.ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies));
        }
    }
}

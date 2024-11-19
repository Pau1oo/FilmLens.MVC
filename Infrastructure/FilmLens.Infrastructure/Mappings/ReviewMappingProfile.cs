using AutoMapper;
using FilmLens.Contracts.Reviews;
using FilmLens.Domain.Entities;

namespace FilmLens.Infrastructure.Mappings
{
	public sealed class ReviewMappingProfile : Profile
	{
        public ReviewMappingProfile()
        {
            CreateMap<Review, ReviewDto>();
			CreateMap<ReviewDto, Review>();
		}
    }
}

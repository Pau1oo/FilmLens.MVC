using FilmLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmLens.DataAccess.MovieReviews.Configurations
{
	public sealed class MovieReviewConfiguration : IEntityTypeConfiguration<MovieReview>
	{
		public void Configure(EntityTypeBuilder<MovieReview> builder)
		{
			builder.ToTable("MovieReviews");

			builder.HasKey(mr => new { mr.MovieId, mr.ReviewId });

			builder.HasOne<Movie>() 
		    .WithMany()          
		    .HasForeignKey(mr => mr.MovieId) 
		    .OnDelete(DeleteBehavior.Cascade);

			builder.HasOne<Review>() 
			.WithOne()           
			.HasForeignKey<MovieReview>(mr => mr.ReviewId) 
			.OnDelete(DeleteBehavior.Cascade);
		}
	}
}

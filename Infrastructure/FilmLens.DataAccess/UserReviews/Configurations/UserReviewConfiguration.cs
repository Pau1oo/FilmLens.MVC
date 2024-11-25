using FilmLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmLens.DataAccess.UserReviews.Configurations
{
	public sealed class UserReviewConfiguration : IEntityTypeConfiguration<UserReview>
	{
		public void Configure(EntityTypeBuilder<UserReview> builder)
		{
			builder.ToTable("UserReviews");

			builder.HasKey(ur => new { ur.UserId, ur.ReviewId });

			builder.HasOne<User>()
			.WithMany()
			.HasForeignKey(ur => ur.UserId)
			.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne<Review>()
			.WithOne()
			.HasForeignKey<UserReview>(ur => ur.ReviewId)
			.OnDelete(DeleteBehavior.Cascade);
		}
	}
}

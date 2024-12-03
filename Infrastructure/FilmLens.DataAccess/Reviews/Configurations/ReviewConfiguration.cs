using FilmLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmLens.DataAccess.Reviews.Configurations
{
	public sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
	{
		public void Configure(EntityTypeBuilder<Review> builder)
		{
			builder.ToTable("reviews");

			builder.HasKey(r => r.Id);

			builder.HasIndex(r => r.ReviewedMovieId);
			builder.HasIndex(r => r.ReviewerUserId);

			builder.HasOne(r => r.User)
				   .WithMany(u => u.Reviews)
				   .HasForeignKey(r => r.ReviewerUserId)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(r => r.Movie)
				   .WithMany(m => m.Reviews)
				   .HasForeignKey(r => r.ReviewedMovieId)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.Property(r => r.ReviewText)
				   .IsRequired()
				   .HasMaxLength(2000);

			builder.Property(r => r.CreatedAt)
				   .IsRequired();
		}
	}
}

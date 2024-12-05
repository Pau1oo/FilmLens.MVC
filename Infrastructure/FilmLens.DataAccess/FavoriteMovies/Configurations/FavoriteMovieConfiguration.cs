using FilmLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmLens.DataAccess.FavoriteMovies.Configurations
{
	public sealed class FavoriteMovieConfiguration : IEntityTypeConfiguration<FavoriteMovie>
	{
		public void Configure(EntityTypeBuilder<FavoriteMovie> builder)
		{
			builder.ToTable("favoriteMovies");

			builder.HasKey(fm => new { fm.UserId, fm.MovieId });

			builder.HasOne(fm => fm.User)
				   .WithMany(u => u.FavoriteMovies)
				   .HasForeignKey(fm => fm.UserId)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(fm => fm.Movie)
				   .WithMany(m => m.FavoriteByUsers)
				   .HasForeignKey(fm => fm.MovieId)
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FilmLens.Domain.Entities;

namespace FilmLens.DataAccess.Movies.Configurations
{
	public sealed class MovieConfiguration : IEntityTypeConfiguration<Movie>
	{
		public void Configure(EntityTypeBuilder<Movie> builder)
		{
			builder.ToTable("movies");

			builder.HasKey(m => m.Id);

			builder.Property(m => m.Title)
			.IsRequired(true)
			.HasMaxLength(200);

			builder.Property(m => m.Overview)
				.IsRequired(true)
				.HasMaxLength(1000);

			builder.Property(m => m.ReleaseDate)
				.IsRequired(true);

			builder.Property(m => m.VoteAverage)
				.HasColumnType("decimal(3, 1)");

			builder.Property(m => m.VoteCount)
				.HasDefaultValue(0);

			builder.Property(m => m.PosterPath)
				.HasMaxLength(500);

			builder.Property(m => m.Tagline)
				.HasMaxLength(300);

			builder.Property(m => m.TmdbId)
				.IsRequired(true)
				.HasMaxLength(50);

			builder.HasMany(m => m.Genres)
				.WithMany(g => g.Movies)
				.UsingEntity<Dictionary<string, object>>(
					"MovieGenre",
					j => j.HasOne<Genre>()
						  .WithMany()
						  .HasForeignKey("GenreId")
						  .OnDelete(DeleteBehavior.Cascade),
					j => j.HasOne<Movie>()
						  .WithMany()
						  .HasForeignKey("MovieId")
						  .OnDelete(DeleteBehavior.Cascade),
					j =>
					{
						j.HasKey("MovieId", "GenreId");
						j.ToTable("MovieGenres");
					});
		}
	}
}

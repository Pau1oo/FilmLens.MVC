using FilmLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmLens.DataAccess.MovieGenres.Configurations
{
	public sealed class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
	{
		public void Configure(EntityTypeBuilder<MovieGenre> builder)
		{
			builder.HasKey(j => j.MovieId);
			builder.HasKey(j => j.GenreId);
		}
	}
}

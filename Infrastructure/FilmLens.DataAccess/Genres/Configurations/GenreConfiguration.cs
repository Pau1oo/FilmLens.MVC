using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FilmLens.Domain.Entities;

namespace FilmLens.DataAccess.Genres.Configurations
{
	public sealed class GenreConfiguration : IEntityTypeConfiguration<Genre>
	{
		public void Configure(EntityTypeBuilder<Genre> builder)
		{
			builder.ToTable("genres");

			builder.HasKey(g => g.Id);

			builder.Property(g => g.Name)
				.IsRequired(true)
				.HasMaxLength(100);
		}
	}
}

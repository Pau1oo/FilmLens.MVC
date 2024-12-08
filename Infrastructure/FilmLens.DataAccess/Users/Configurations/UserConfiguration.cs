using FilmLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmLens.DataAccess.Users.Configurations
{
	public sealed class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("users");

			builder.HasKey(t => t.Id);

			builder.Property(u => u.CreatedAt)
				.IsRequired();
		}
	}
}

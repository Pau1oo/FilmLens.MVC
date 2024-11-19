using FilmLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmLens.DataAccess.Users.Configurations
{
	public sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.ToTable("roles");

			builder.HasKey(x => x.Id);

			builder.HasData(new Role
			{
				Id = 1,
				Name = "User"
			},
			new Role
			{
				Id = 2,
				Name = "Admin"
			});
		}
	}
}

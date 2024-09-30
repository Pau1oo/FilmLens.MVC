using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FilmLens.Domain.Entities;

namespace FilmLens.DataAccess.Common
{
    public class MutableFilmLensDbContext : IdentityDbContext<User, Role, int>
    {
        public MutableFilmLensDbContext() : base()
        {
            
        }

        public MutableFilmLensDbContext(DbContextOptions<MutableFilmLensDbContext> options) 
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MutableFilmLensDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

       // public DbSet<ProductAttribute> Attributes { get; set; }
    }
}

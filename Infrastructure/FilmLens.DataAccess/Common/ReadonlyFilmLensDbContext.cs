using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FilmLens.Domain.Entities;

namespace FilmLens.DataAccess.Common
{
    public class ReadonlyFilmLensDbContext : IdentityDbContext<User, Role, int>
    {
        //public ReadonlyOnlineStoreDbContext() : base()
        //{

        //}

        public ReadonlyFilmLensDbContext(DbContextOptions<ReadonlyFilmLensDbContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReadonlyFilmLensDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}

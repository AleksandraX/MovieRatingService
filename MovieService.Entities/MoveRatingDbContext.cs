using Microsoft.EntityFrameworkCore;
using MovieService.Entities.Entities;

namespace MovieService.Entities
{
    public class MoveRatingDbContext : DbContext
    {
        public MoveRatingDbContext(DbContextOptions<MoveRatingDbContext> options)
            : base(options)
        { }


        public DbSet<FilmRate> FilmRates { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmRate>().HasKey(x => x.FilmId);

            modelBuilder.Entity<FilmRate>().HasData(
                new FilmRate
                {
                    FilmId = 1,
                    Count = 125,
                    Sum = 700
                },
                 new FilmRate
                 {
                     FilmId = 2,
                     Count = 35,
                     Sum = 300
                 },
                  new FilmRate
                  {
                      FilmId = 3,
                      Count = 80,
                      Sum = 600
                  },
                   new FilmRate
                   {
                       FilmId = 4,
                       Count = 100,
                       Sum = 700
                   },
                    new FilmRate
                    {
                        FilmId = 5,
                        Count = 112,
                        Sum = 700
                    },
                     new FilmRate
                     {
                         FilmId = 6,
                         Count = 100,
                         Sum = 200
                     }
                );
        }
    }
}
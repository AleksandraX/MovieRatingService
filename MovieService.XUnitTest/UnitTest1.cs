using Microsoft.EntityFrameworkCore;
using MovieService.Entities;
using MovieService.Entities.Entities;
using System;
using System.Linq;
using Xunit;

namespace MovieService.XUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldBeAbleToAddInMemoryDb()
        {
            var builder = new DbContextOptionsBuilder<MoveRatingDbContext>()
                .EnableSensitiveDataLogging()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());


            using(var context = new MoveRatingDbContext(builder.Options))
            {
                int filmIdToTest = 7;

                context.FilmRates.Add(new FilmRate
                {
                    FilmId = filmIdToTest,
                    Count = 100,
                    Sum = 600
                });
                context.SaveChanges();

                Assert.Equal(1, context.FilmRates.Count(fr => fr.FilmId == filmIdToTest));
            }
        }
    }
}

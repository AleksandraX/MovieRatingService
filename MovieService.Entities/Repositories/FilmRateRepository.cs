using Microsoft.EntityFrameworkCore;
using MovieService.Entities.Entities;
using MovieService.Entities.Interfaces;
using MovieService.Models;
using System.Threading.Tasks;

namespace MovieService.Entities.Repositories
{
    public class FilmRateRepository : IFilmRateRepository
    {
        private readonly MoveRatingDbContext context;
        private readonly DbSet<FilmRate> dbSet;
        public FilmRateRepository(MoveRatingDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<FilmRate>();
        }

        public async Task<FilmRateDto> GetScoreByFilmId(int id)
        {
            var filmRate = await this.dbSet.AsNoTracking().FirstOrDefaultAsync(fr => fr.FilmId == id);

            var filmRateDto = new FilmRateDto
            {
                PeopleVoted = filmRate.Count,
                Score = (decimal)filmRate.Sum / (decimal)filmRate.Count
            };

            return filmRateDto;
        }

        public async Task<bool> UpdateFilmRate(int filmId, int rate)
        {
            var filmRate = await this.dbSet.FirstOrDefaultAsync(fr => fr.FilmId == filmId);

            if(filmRate == null)
            {
                return false;
            }

            filmRate.Count += 1;
            filmRate.Sum += rate;

            await this.context.SaveChangesAsync();

            return true;
        }
    }
}


using MovieService.Models;
using System.Threading.Tasks;

namespace MovieService.Entities.Interfaces
{
    public interface IFilmRateRepository
    {
        Task<FilmRateDto> GetScoreByFilmId(int id);
        Task<bool> UpdateFilmRate(int filmId, int rate);
    }
}

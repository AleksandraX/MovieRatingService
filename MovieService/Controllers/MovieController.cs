using Microsoft.AspNetCore.Mvc;
using MovieService.Entities.Interfaces;
using MovieService.Models;
using MovieService.ViewModels;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private string apiUrl = "https://swapi.dev/api";
        private readonly IFilmRateRepository filmRateRepository;

        public MovieController(IFilmRateRepository filmRateRepository)
        {
            this.filmRateRepository = filmRateRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetFilms()
        {
            string json = await this.SendRequest($"{apiUrl}/films/");

            ResultDto<FilmDto> swapiResponse = JsonConvert.DeserializeObject<ResultDto<FilmDto>>(json);

            var films = swapiResponse.Results.Select(x => new FilmListItemViewModel()
            {
                Id = x.Url.Replace('/', ' ').Trim().Last().ToString(),
                Title = x.Title,
                Description = x.OpeningCrawl,
                Producer = x.Producer,
                ReleaseYear = DateTime.Parse(x.ReleaseDate).Year.ToString()
            }).ToList(); 

            return Ok(films);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetFilmById(int id)
        {
            string json = await this.SendRequest($"{apiUrl}/films/{id}/");

            FilmDto film = JsonConvert.DeserializeObject<FilmDto>(json);
            film.FilmRate = await this.filmRateRepository.GetScoreByFilmId(id);

            return Ok(film);
        }

        [HttpGet("[action]/{filmId}")]
        public async Task<IActionResult> GetFilmRate(int filmId)
        {
            var filmRate = await this.filmRateRepository.GetScoreByFilmId(filmId);

            return Ok(filmRate);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> RateTheFilm([FromQuery] int filmId, int score)
        {
           var result = await this.filmRateRepository.UpdateFilmRate(filmId, score);

            if(result)
            {
                var filmRate = await this.filmRateRepository.GetScoreByFilmId(filmId);
                return Ok(filmRate);
            }

            return new BadRequestResult();
        }

        private async Task<String> SendRequest(string requestUrl)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl),
                Headers =
                    {
                        { "Accept", "application/json" },
                    },
            };      

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                return body;
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace MovieService.Models
{
    public class FilmDto
    {
        [JsonPropertyName("characters")]
        public List<string> Characters { get; set; }

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("director")]
        public string Director { get; set; }

        [JsonPropertyName("edited")]
        public DateTime Edited { get; set; }

        [JsonProperty("episode_id")]
        public int EpisodeId { get; set; }

        [JsonProperty("opening_crawl")]
        public string OpeningCrawl { get; set; }

        [JsonPropertyName("planets")]
        public List<string> Planets { get; set; }

        [JsonPropertyName("producer")]
        public string Producer { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("species")]
        public List<string> Species { get; set; }

        [JsonPropertyName("starships")]
        public List<string> Starships { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("vehicles")]
        public List<string> Vehicles { get; set; }

        public FilmRateDto FilmRate { get; set; }
    }
}

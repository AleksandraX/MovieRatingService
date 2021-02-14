using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MovieService.Models
{
    public class ResultDto<T> where T : class
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("next")]
        public object Next { get; set; }

        [JsonPropertyName("previous")]
        public object Previous { get; set; }

        [JsonPropertyName("results")]
        public List<T> Results { get; set; }
    }
}

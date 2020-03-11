using Newtonsoft.Json;

namespace PokemonAPI.Services
{
    public class ContentDto
    {
        [JsonProperty("translated")]
        public string Translated { get; set; }
    }
}
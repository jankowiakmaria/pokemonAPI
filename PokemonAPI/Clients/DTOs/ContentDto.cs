using Newtonsoft.Json;

namespace PokemonAPI.Clients.DTOs
{
    public class ContentDto
    {
        [JsonProperty("translated")]
        public string Translated { get; set; }
    }
}
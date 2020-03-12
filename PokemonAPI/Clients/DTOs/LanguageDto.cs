using Newtonsoft.Json;

namespace PokemonAPI.Clients.DTOs
{
    public class LanguageDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
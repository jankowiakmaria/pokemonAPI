using Newtonsoft.Json;

namespace PokemonAPI.Services.DTOs
{
    public class LanguageDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
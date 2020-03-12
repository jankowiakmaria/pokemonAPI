using Newtonsoft.Json;

namespace PokemonAPI.Clients.DTOs
{
    public class TextEntryDto
    {
        [JsonProperty("flavor_text")]
        public string Text { get; set; }

        [JsonProperty("language")]
        public LanguageDto Language { get; set; }
    }
}
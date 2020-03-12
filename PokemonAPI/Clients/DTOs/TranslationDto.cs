using Newtonsoft.Json;

namespace PokemonAPI.Clients.DTOs
{
    internal class TranslationDto
    {
        [JsonProperty("contents")]
        public ContentDto Content { get; set; }
    }
}
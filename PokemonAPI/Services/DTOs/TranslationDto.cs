using Newtonsoft.Json;

namespace PokemonAPI.Services
{
    internal class TranslationDto
    {
        [JsonProperty("contents")]
        public ContentDto Content { get; set; }
    }
}
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokemonAPI.Clients.DTOs
{
    public class PokemonDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("flavor_text_entries")]
        public List<TextEntryDto> TextEntries { get; set; }
    }
}

using PokemonAPI.Clients.DTOs;
using System.Linq;

namespace PokemonAPI.Entities
{
    public class Pokemon
    {
        private const string _language = "en";

        public Pokemon(PokemonDto pokemonDto)
        {
            Name = pokemonDto.Name;
            Description = pokemonDto
                .TextEntries?
                .FirstOrDefault(t => t.Language.Name == _language)?.Text ?? string.Empty;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}

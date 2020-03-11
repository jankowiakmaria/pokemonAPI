using PokemonAPI.Services.DTOs;
using System.Linq;

namespace PokemonAPI.Entities
{
    public class Pokemon
    {
        public Pokemon(PokemonDto pokemonDto, string language)
        {
            Name = pokemonDto.Name;
            Description = pokemonDto.TextEntries.First(t => t.Language.Name == language).Text;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}

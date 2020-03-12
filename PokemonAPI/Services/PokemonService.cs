using PokemonAPI.Entities;
using System;
using System.Threading.Tasks;

namespace PokemonAPI.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonClient _pokemonClient;
        private readonly ITranslatorClient _translatorClient;

        public PokemonService(IPokemonClient pokemonClient, ITranslatorClient translatorClient)
        {
            _pokemonClient = pokemonClient;
            _translatorClient = translatorClient;
        }

        public async Task<ShakespearePokemon> GetPokemon(string name)
        {
            var pokemon = await _pokemonClient.GetPokemon(name);
            if(pokemon != null)
            {
                var description = await _translatorClient.Translate(pokemon.Description);
                if(description != null)
                {
                    return new ShakespearePokemon(pokemon, description);
                }
            }

            return null;
            throw new NotImplementedException();
        }
    }
}

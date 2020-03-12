using PokemonAPI.Clients;
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
            var pokemonResult = await _pokemonClient.GetPokemon(name);
            if (pokemonResult.Failed)
            {
                return null; // todo: change to proper code
            }

            var pokemon = pokemonResult.Value;
            var descriptionResult = await _translatorClient.Translate(pokemon.Description);
            if (descriptionResult.Failed)
            {
                return null; //do something meaningfull
            }

            return new ShakespearePokemon(pokemon, descriptionResult.Value);
        }
    }
}

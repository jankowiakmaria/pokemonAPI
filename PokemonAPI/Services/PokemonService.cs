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

        public async Task<Result<ShakespearePokemon>> GetPokemon(string name)
        {
            var pokemonResult = await _pokemonClient.GetPokemon(name);
            if (pokemonResult.Failed)
            {
                return pokemonResult.ErrorResult;
            }

            var pokemon = pokemonResult.Value;
            var descriptionResult = await _translatorClient.Translate(pokemon.Description);
            if (descriptionResult.Failed)
            {
                return descriptionResult.ErrorResult;
            }

            return new ShakespearePokemon(pokemon, descriptionResult.Value);
        }
    }
}

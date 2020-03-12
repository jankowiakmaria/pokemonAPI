using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonAPI.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonAPITests.Integration
{
    [TestClass]
    public class PokemonClientTests
    {
        private readonly string _knownPokemon = "charizard";
        private readonly string _notExistingPokemon = "not_existing_pokemon_name";

        private PokemonClient pokemonClient;

        [TestInitialize]
        public void Setup()
        {
            var client = HttpClientFactory.Create();
            client.BaseAddress = new Uri("https://pokeapi.co");
            client.DefaultRequestHeaders.Add("Accept", "Application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "Pokemon API");

            pokemonClient = new PokemonClient(client);
        }

        [TestMethod]
        public async Task deserializes_response_from_the_service_when_pokemon_exists()
        {
            var result = await pokemonClient.GetPokemon(_knownPokemon);

            Assert.AreEqual(_knownPokemon, result.Name);
            Assert.IsNotNull(result.Description);
        }

        [TestMethod]
        public async Task returns_null_when_pokemon_does_not_exist()
        {
            var result = await pokemonClient.GetPokemon(_notExistingPokemon);

            Assert.IsNull(result);
        }
    }
}

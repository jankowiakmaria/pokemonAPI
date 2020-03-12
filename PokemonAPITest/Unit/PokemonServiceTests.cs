using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PokemonAPI.Clients;
using PokemonAPI.Clients.DTOs;
using PokemonAPI.Entities;
using PokemonAPI.Services;
using System.Net;
using System.Threading.Tasks;
using static PokemonAPI.Clients.Result;

namespace PokemonAPITests.Unit
{
    [TestClass]
    public class PokemonServiceTests
    {
        private readonly string _knownName = "charizard";
        private readonly string _knownDescription = "A description of the pokemon";
        private Mock<IPokemonClient> _pokemonClient;
        private Mock<ITranslatorClient> _translatorClient;

        private PokemonService _pokemonService;

        private ErrorResultContent _errorResult = new ErrorResultContent(HttpStatusCode.NotFound, "Error");


        [TestInitialize]
        public void Setup()
        {
            _pokemonClient = new Mock<IPokemonClient>();
            _translatorClient = new Mock<ITranslatorClient>();

            _pokemonService = new PokemonService(_pokemonClient.Object, _translatorClient.Object);
        }

        [TestMethod]
        public async Task returns_failed_pokemon_result()
        {
            var pokemonResult = new Result<Pokemon>(_errorResult);
            _pokemonClient.Setup(c => c.GetPokemon(_knownName))
                .Returns(Task.FromResult(pokemonResult));

            var result = await _pokemonService.GetPokemon(_knownName);

            Assert.IsTrue(result.Failed);
            Assert.AreEqual(_errorResult, result.ErrorResult);
        }

        [TestMethod]
        public async Task returns_failed_translation_result()
        {
            var pokemonResult = new Result<Pokemon>(new Pokemon(new PokemonDto()));
            _pokemonClient.Setup(c => c.GetPokemon(_knownName))
                .Returns(Task.FromResult(pokemonResult));
            _translatorClient.Setup(c => c.Translate(""))
                .Returns(Task.FromResult(new Result<string>(_errorResult)));

            var result = await _pokemonService.GetPokemon(_knownName);

            Assert.IsTrue(result.Failed);
            Assert.AreEqual(_errorResult, result.ErrorResult);
        }

        [TestMethod]
        public async Task returns_pokemon_with_description()
        {
            var pokemonResult = new Result<Pokemon>(new Pokemon(new PokemonDto { Name = _knownName}));
            _pokemonClient.Setup(c => c.GetPokemon(_knownName))
                .Returns(Task.FromResult(pokemonResult));
            _translatorClient.Setup(c => c.Translate(""))
                .Returns(Task.FromResult(new Result<string>(_knownDescription)));

            var result = await _pokemonService.GetPokemon(_knownName);

            Assert.IsTrue(result.Succeeded);
            Assert.AreEqual(_knownDescription, result.Value.Description);
            Assert.AreEqual(_knownName, result.Value.Name);
        }
    }
}

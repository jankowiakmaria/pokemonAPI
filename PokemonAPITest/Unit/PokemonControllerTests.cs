using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PokemonAPI.Clients;
using PokemonAPI.Clients.DTOs;
using PokemonAPI.Controllers;
using PokemonAPI.Entities;
using PokemonAPI.Services;
using System.Net;
using System.Threading.Tasks;
using static PokemonAPI.Clients.Result;

namespace PokemonAPITests.Unit
{
    [TestClass]
    public class PokemonControllerTests
    {
        private readonly string _knownName = "charizard";
        private readonly string _knownDescription = "Pokemon description";

        [TestMethod]
        public async Task GetReturnsPokemon()
        {
            var pokemonService = new Mock<IPokemonService>();
            pokemonService.Setup(c => c.GetPokemon(_knownName))
                .Returns(Task.FromResult(
                    new Result<ShakespearePokemon>(
                        new ShakespearePokemon(
                            new Pokemon(new PokemonDto { Name = _knownName }),
                            _knownDescription))));
            var controller = new PokemonController(pokemonService.Object);

            var response = await controller.Get(_knownName);

            Assert.AreEqual(_knownName, response.Value.Name);
            Assert.AreEqual(_knownDescription, response.Value.Description);
        }

        [DataTestMethod]
        [DataRow(HttpStatusCode.NotFound, "Error", 404, "Error")]
        [DataRow(HttpStatusCode.TooManyRequests, "Too many requests", 429, "Too many requests")]
        [DataRow(HttpStatusCode.Unauthorized, "Other error", 500, "There is an underlying service problem.")]
        public async Task GetReturnsError(HttpStatusCode statusCode, string message, int expectedCode, string expectedMessage)
        {
            var pokemonService = new Mock<IPokemonService>();
            var errorResult = new ErrorResultContent(statusCode, message);
            pokemonService.Setup(c => c.GetPokemon(_knownName))
                    .Returns(Task.FromResult(new Result<ShakespearePokemon>(errorResult)));
            var controller = new PokemonController(pokemonService.Object);

            var result = await controller.Get(_knownName);
            var contentResult = result.Result as ContentResult;

            Assert.AreEqual(expectedCode, contentResult.StatusCode);
            Assert.AreEqual(expectedMessage, contentResult.Content);
        }
    }
}

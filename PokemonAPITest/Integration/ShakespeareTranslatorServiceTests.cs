using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonAPI.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonAPITests.Integration
{
    [TestClass]
    public class ShakespeareTranslatorServiceTests
    {
        private readonly string _knownText = "Charizard flies around the sky in search of powerful opponents.";

        private ShakespeareTranslatorService translatorService;

        [TestInitialize]
        public void Setup()
        {
            var client = HttpClientFactory.Create();
            client.BaseAddress = new Uri("https://api.funtranslations.com");
            client.DefaultRequestHeaders.Add("Accept", "Application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "Pokemon API");

            translatorService = new ShakespeareTranslatorService(client);
        }

        [TestMethod]
        public async Task translates_text()
        {
            var result = await translatorService.Translate(_knownText);

            Assert.IsNotNull(result);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonAPI.Clients;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonAPITests.Integration
{
    [TestClass]
    public class ShakespeareTranslatorClientTests
    {
        private readonly string _knownText = "Charizard flies around the sky in search of powerful opponents.";

        private ShakespeareTranslatorClient translatorClient;

        [TestInitialize]
        public void Setup()
        {
            var client = HttpClientFactory.Create();
            client.BaseAddress = new Uri("https://api.funtranslations.com");
            client.DefaultRequestHeaders.Add("Accept", "Application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "Pokemon API");

            translatorClient = new ShakespeareTranslatorClient(client);
        }

        [TestMethod]
        public async Task translates_text_successfully()
        {
            var result = await translatorClient.Translate(_knownText);

            Assert.IsTrue(result.Succeeded);
            Assert.IsNotNull(result.Value);
        }
    }
}

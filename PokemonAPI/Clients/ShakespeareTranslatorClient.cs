using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PokemonAPI.Clients.DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonAPI.Clients
{
    public class ShakespeareTranslatorClient : ITranslatorClient
    {
        private static string _translatePath = "/translate/shakespeare.json";

        private readonly HttpClient _httpClient;
        private readonly ILogger<ShakespeareTranslatorClient> _logger;

        public ShakespeareTranslatorClient(HttpClient httpClient, ILogger<ShakespeareTranslatorClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<Result<string>> Translate(string input)
        {
            var formContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("text", input)
            });

            var response = await _httpClient.PostAsync(_translatePath, formContent);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                TranslationDto translationDto = JsonConvert.DeserializeObject<TranslationDto>(result);

                return translationDto.Content.Translated;
            }

            _logger.LogWarning("The text {input} could not be translated; reason: {reason}", input?.Substring(0, 10), response.ReasonPhrase);
            return response;
        }
    }
}

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonAPI.Services
{
    public class ShakespeareTranslatorService : ITranslatorService
    {
        private static string _translatePath = "/translate/shakespeare.json";

        private readonly HttpClient _httpClient;

        public ShakespeareTranslatorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Translate(string input)
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

            // ideally log warn before returning
            return null;
        }
    }
}

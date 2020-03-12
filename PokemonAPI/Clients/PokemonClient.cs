using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PokemonAPI.Clients.DTOs;
using PokemonAPI.Entities;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonAPI.Clients
{
    public class PokemonClient : IPokemonClient
    {
        private static string _pokemonPath = "api/v2/pokemon-species/";

        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        public PokemonClient(HttpClient httpClient, ILogger<PokemonClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<Result<Pokemon>> GetPokemon(string name)
        {
            var response = await _httpClient.GetAsync(_pokemonPath + name);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                PokemonDto pokemonDto = JsonConvert.DeserializeObject<PokemonDto>(result);
                return new Pokemon(pokemonDto);
            }

            _logger.LogWarning("The pokemon named '{name}' could not be retrieved; reason: {reason}", name, response.ReasonPhrase);
            return response;
        }
    }
}

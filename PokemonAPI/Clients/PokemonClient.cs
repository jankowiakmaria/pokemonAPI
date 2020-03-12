﻿using Newtonsoft.Json;
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

        public PokemonClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
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

            // ideally log warn before returning
            return response;
        }
    }
}

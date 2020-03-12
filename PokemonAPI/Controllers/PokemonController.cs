using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Entities;
using PokemonAPI.Extensions;
using PokemonAPI.Services;
using System.Threading.Tasks;

namespace PokemonAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService) => _pokemonService = pokemonService;

        // GET: pokemon/charizard
        [HttpGet("{name}", Name = "Get")]
        public async Task<ShakespearePokemon> Get(
            [NotNullOrWhiteSpaceString][NotNumericString] string name)
        {
            return await _pokemonService.GetPokemon(name);
        }

        //todo: argument validation
    }
}

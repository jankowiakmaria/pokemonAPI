using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Attributes;
using PokemonAPI.Clients;
using PokemonAPI.Entities;
using PokemonAPI.Services;
using System.Net;
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
        public async Task<ActionResult<ShakespearePokemon>> Get(
            [NotNullOrWhiteSpaceString][NotNumericString] string name)
        {
            var pokemonResult = await _pokemonService.GetPokemon(name);

            if(pokemonResult.Succeeded)
            {
                return pokemonResult.Value;
            }

            return HandleFailure(pokemonResult);
        }

        private ContentResult HandleFailure(Result<ShakespearePokemon> result) 
        {
            if(result.StatusCode == HttpStatusCode.NotFound || result.StatusCode == HttpStatusCode.TooManyRequests)
            {
                return new ContentResult
                {
                    StatusCode = (int?)result.StatusCode,
                    Content = result.ErrorMessage
                };
            }

            return new ContentResult
            {
                StatusCode = (int?)HttpStatusCode.InternalServerError,
                Content = "There is an underlying service problem."
            };
        }
    }
}

using PokemonAPI.Clients;
using PokemonAPI.Entities;
using System.Threading.Tasks;

namespace PokemonAPI.Services
{
    public interface IPokemonClient
    {
        Task<Result<Pokemon>> GetPokemon(string name);
    }
}

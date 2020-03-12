using PokemonAPI.Entities;
using System.Threading.Tasks;

namespace PokemonAPI.Clients
{
    public interface IPokemonClient
    {
        Task<Result<Pokemon>> GetPokemon(string name);
    }
}

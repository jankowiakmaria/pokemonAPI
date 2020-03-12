using PokemonAPI.Clients;
using PokemonAPI.Entities;
using System.Threading.Tasks;

namespace PokemonAPI.Services
{
    public interface IPokemonService
    {
        Task<Result<ShakespearePokemon>> GetPokemon(string name);
    }
}

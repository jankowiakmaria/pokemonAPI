using PokemonAPI.Entities;
using System.Threading.Tasks;

namespace PokemonAPI.Services
{
    public interface IPokemonClient
    {
        Task<Pokemon> GetPokemon(string name);
    }
}

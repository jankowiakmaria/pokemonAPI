using PokemonAPI.Entities;
using System.Threading.Tasks;

namespace PokemonAPI.Services
{
    public interface IPokemonService
    {
        Task<Pokemon> GetPokemon(string name);
    }
}

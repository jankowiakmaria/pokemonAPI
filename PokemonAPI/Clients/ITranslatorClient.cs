using PokemonAPI.Clients;
using System.Threading.Tasks;

namespace PokemonAPI.Services
{
    public interface ITranslatorClient
    {
        Task<Result<string>> Translate(string input);
    }
}

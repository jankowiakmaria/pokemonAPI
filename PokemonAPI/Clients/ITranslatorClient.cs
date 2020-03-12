using System.Threading.Tasks;

namespace PokemonAPI.Clients
{
    public interface ITranslatorClient
    {
        Task<Result<string>> Translate(string input);
    }
}

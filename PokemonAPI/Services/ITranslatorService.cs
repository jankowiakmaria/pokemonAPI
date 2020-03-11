using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPI.Services
{
    interface ITranslatorService
    {
        Task<string> Translate(string input);
    }
}

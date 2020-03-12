﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPI.Services
{
    public interface ITranslatorClient
    {
        Task<string> Translate(string input);
    }
}

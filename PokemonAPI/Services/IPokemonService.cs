﻿using PokemonAPI.Entities;
using System.Threading.Tasks;

namespace PokemonAPI.Services
{
    public interface IPokemonService
    {
        Task<ShakespearePokemon> GetPokemon(string name);
    }
}

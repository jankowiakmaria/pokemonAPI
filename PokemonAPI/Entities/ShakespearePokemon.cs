﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPI.Entities
{
    public class ShakespearePokemon
    {
        private readonly Pokemon _pokemon;

        public ShakespearePokemon(Pokemon pokemon, string description)
        {
            _pokemon = pokemon;
            Description = description;
        }

        public string Name => _pokemon.Name;

        public string Description { get; private set; }
    }
}

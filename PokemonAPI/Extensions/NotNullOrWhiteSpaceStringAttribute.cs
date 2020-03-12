﻿using System.ComponentModel.DataAnnotations;

namespace PokemonAPI.Extensions
{
    public class NotNullOrWhiteSpaceStringAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return !string.IsNullOrWhiteSpace(value as string);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonAPI.Clients.DTOs;
using PokemonAPI.Entities;
using System.Collections.Generic;

namespace PokemonAPITests.Unit
{
    [TestClass]
    public class PokemonTest
    {
        private const string _knownDescription = "english pokemon description";
        private const string _knownName = "charizard";

        private const string _foreignDescription = "polski opis do pokemona";
        private readonly TextEntryDto _foreignLanguageEntry =
            new TextEntryDto { Language = new LanguageDto { Name = "pl" }, Text = _foreignDescription };

        [TestMethod]
        public void returns_correct_name_and_description_when_provided_in_dto()
        {
            var dto = new PokemonDto
            {
                Name = _knownName,
                TextEntries = new List<TextEntryDto>{
                    _foreignLanguageEntry,
                    new TextEntryDto { Language = new LanguageDto { Name = "en"}, Text = _knownDescription}
                }
            };

            var pokemon = new Pokemon(dto);

            Assert.AreEqual(_knownName, pokemon.Name);
            Assert.AreEqual(_knownDescription, pokemon.Description);
        }

        [TestMethod]
        public void returns_correct_name_and_empty_description_when_language_not_provided_in_dto()
        {
            var dto = new PokemonDto
            {
                Name = _knownName,
                TextEntries = new List<TextEntryDto> { _foreignLanguageEntry }
            };

            var pokemon = new Pokemon(dto);

            Assert.AreEqual(_knownName, pokemon.Name);
            Assert.AreEqual(string.Empty, pokemon.Description);
        }

        [TestMethod]
        public void returns_correct_name_and_empty_description_when_entries_provided_in_dto()
        {
            var dto = new PokemonDto
            {
                Name = _knownName
            };

            var pokemon = new Pokemon(dto);

            Assert.AreEqual(_knownName, pokemon.Name);
            Assert.AreEqual(string.Empty, pokemon.Description);
        }
    }
}

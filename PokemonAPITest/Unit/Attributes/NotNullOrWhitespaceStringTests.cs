using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonAPI.Attributes;

namespace PokemonAPITests.Unit.Attributes
{
    [TestClass]
    public class NotNullOrWhitespaceStringTests
    {
        [DataTestMethod]
        [DataRow(null, false)]
        [DataRow("", false)]
        [DataRow("      \t\n", false)]
        [DataRow("\n", false)]
        [DataRow("1", true)]
        [DataRow(7, false)]
        [DataRow(true, false)]
        public void Validates_the_Input(object input, bool expected)
        {
            Assert.AreEqual(expected, new NotNullOrWhiteSpaceStringAttribute().IsValid(input));
        }
    }
}

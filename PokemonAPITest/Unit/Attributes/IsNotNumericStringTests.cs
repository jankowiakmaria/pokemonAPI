using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonAPI.Attributes;

namespace PokemonAPITests.Unit.Attributes
{
    [TestClass]
    public class IsNotNumericStringTests
    {
        [DataTestMethod]
        [DataRow(null, true)]
        [DataRow("", true)]
        [DataRow(" ", true)]
        [DataRow("text", true)]
        [DataRow("1", false)]
        [DataRow("1    ", false)]
        [DataRow("1.5", false)]
        [DataRow(7, false)]
        [DataRow(true, false)]
        public void Validates_the_Input(object input, bool expected)
        {
            Assert.AreEqual(expected, new NotNumericStringAttribute().IsValid(input));
        }
    }
}

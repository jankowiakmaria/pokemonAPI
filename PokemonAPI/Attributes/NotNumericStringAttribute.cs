using System.ComponentModel.DataAnnotations;

namespace PokemonAPI.Attributes
{
    public class NotNumericStringAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (!(value is string stringValue)) return false;

            var isNumber = double.TryParse(stringValue, out _);

            return !isNumber;
        }
    }
}

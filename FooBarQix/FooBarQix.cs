using System.Collections.Generic;
using System.Text;

namespace FooBarQix
{
    public static class FooBarQix
    {
        private static readonly Dictionary<int, string> Tokens = new Dictionary<int, string> { { 3, "Foo" }, { 5, "Bar" }, {7, "Qix"} };

        public static string Transform(string number)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var numberParsed = int.Parse(number);

            foreach (var token in Tokens)
            {
                if (number.Contains(token.Key.ToString())) stringBuilder.Append(token.Value);
                if (numberParsed % token.Key == 0) stringBuilder.Append(token.Value);
            }

            var formattedString = stringBuilder.ToString();
            return string.IsNullOrEmpty(formattedString) ? number : formattedString;
        }
    }
}
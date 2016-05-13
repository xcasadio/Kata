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
                if (ContainsNumber(number, token.Key)) stringBuilder.Append(token.Value);
                if (numberParsed.IsDivisibleBy(token.Key)) stringBuilder.Append(token.Value);
            }

            var formattedString = stringBuilder.ToString();

            return IsNoRuleApply(formattedString) ? number : formattedString;
        }

        private static bool IsNoRuleApply(string formattedString)
        {
            return string.IsNullOrEmpty(formattedString);
        }

        private static bool ContainsNumber(string number, int token)
        {
            return number.Contains(token.ToString());
        }
    }
}
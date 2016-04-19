using System.Collections.Generic;
using System.Linq;

namespace DictionaryReplacer
{
    public class DictionaryReplacer
    {
        private readonly Dictionary<string, string> _tokens = new Dictionary<string, string>();

        public void AddToken(string key, string value)
        {
            _tokens[key] = value;
        }

        public string Transform(string sentence)
        {
            return string.IsNullOrEmpty(sentence) ? string.Empty : _tokens.Aggregate(sentence, (current, token) => current.Replace("$" + token.Key + "$", token.Value));
        }
    }
}
namespace KataWordWrap
{
    static class WordWrap
    {
        public static string Wrap(string text, int columnNumber)
        {
            if (IsTextLessThanColumNumber(text, columnNumber))
            {
                return text;
            }
            else if (IsSpace(text, columnNumber))
            {
                return text.Substring(0, columnNumber) + '\n' + Wrap(text.Substring(columnNumber + 1), columnNumber);
            }
            else
            {
                if (ContainsSpaceBeforeColumnNumber(text, columnNumber))
                {
                    return text.Substring(0, text.LastIndexOfAny(new[] { ' ' }, columnNumber)) + '\n' + 
                           Wrap(text.Substring(text.LastIndexOfAny(new[] { ' ' }, columnNumber) + 1), columnNumber);
                }

                return text.Substring(0, columnNumber) + '\n' + Wrap(text.Substring(columnNumber), columnNumber);
            }
        }

        private static bool IsTextLessThanColumNumber(string text, int columnNumber)
        {
            return columnNumber >= text.Length;
        }

        private static bool IsSpace(string text, int columnNumber)
        {
            return text[columnNumber] == ' ';
        }

        private static bool ContainsSpaceBeforeColumnNumber(string text, int columnNumber)
        {
            return text.LastIndexOfAny(new[] {' '}, columnNumber) != -1;
        }
    }
}
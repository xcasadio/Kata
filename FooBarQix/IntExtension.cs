namespace FooBarQix
{
    internal static class IntExtension
    {
        public static bool IsDivisibleBy(this int numberParsed, int divisor)
        {
            return numberParsed % divisor == 0;
        }
    }
}
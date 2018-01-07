using System.Linq;
using MercyBot.WPF;

namespace MercyBot.Utility.Extensions
{
    public static class StringsExtensions
    {

        // Fields
        private static readonly string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789%";


        public static string ToCamelCase(this string text)
            => $"{char.ToLower(text[0])}{text.Substring(1)}";

        public static string Capitalize(this string text)
            => $"{char.ToUpper(text[0])}{text.Substring(1)}";

        public static string PureCapitalize(this string text)
            => $"{char.ToUpper(text[0])}{text.Substring(1).ToLower()}";

        public static string ToRandomString(this int length)
            => new string(Enumerable.Repeat(characters, length).Select(s => s[Randomize.GetRandomInt(0, s.Length)]).ToArray());

        public static string Truncate(this string text, int maxLength)
            => text.Length <= maxLength ? text : $"{text.Substring(0, maxLength)}...";

        public static string SetCulture(this string text)
            => text.ToString(App.Culture);

    }
}
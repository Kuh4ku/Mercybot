using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MercyBot.Protocol
{
    public static class Extensions
    {

        public static async Task<JObject> ReadAsJsonAsync(this HttpContent content)
        {
            var txtContent = await content.ReadAsStringAsync().ConfigureAwait(false);
            var jObj = JObject.Parse(txtContent);
            return jObj;
        }

        public static string ToCamelCase(this string text) => $"{char.ToLower(text[0])}{text.Substring(1)}";

    }
}

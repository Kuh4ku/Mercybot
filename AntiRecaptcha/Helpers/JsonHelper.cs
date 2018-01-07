using Newtonsoft.Json;
using System.Globalization;

namespace AntiRecaptcha.Helpers
{
    public class JsonHelper
    {

        public static string ExtractStr(dynamic json, string firstLevel, string secondLevel = null)
        {
            var path = firstLevel + (secondLevel == null ? "" : "=>" + secondLevel);

            try
            {
                object result = json[firstLevel];

                if (result != null && secondLevel != null)
                {
                    result = json[firstLevel][secondLevel];
                }

                if (result == null)
                {
                    return null;
                }

                return result.ToString();
            }
            catch
            {
                return null;
            }
        }

        public static string AsString(dynamic json)
            => JsonConvert.SerializeObject(json, Formatting.Indented);

        public static double? ExtractDouble(dynamic json, string firstLevel, string secondLevel = null)
        {
            double outDouble;
            string numberAsStr = ExtractStr(json, firstLevel, secondLevel);

            if (numberAsStr == null ||
                !double.TryParse(numberAsStr.Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture,
                    out outDouble))
            {
                var path = firstLevel + (secondLevel == null ? "" : "=>" + secondLevel);

                return null;
            }

            return outDouble;
        }

        public static int? ExtractInt(dynamic json, string firstLevel, string secondLevel = null)
        {
            int outInt;
            string numberAsStr = JsonHelper.ExtractStr(json, firstLevel, secondLevel);

            if (!int.TryParse(numberAsStr, out outInt))
            {
                var path = firstLevel + (secondLevel == null ? "" : "=>" + secondLevel);

                return null;
            }

            return outInt;
        }
    }
}

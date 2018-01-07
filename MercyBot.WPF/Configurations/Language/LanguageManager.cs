using System.Collections.Generic;
using System.IO;

namespace MercyBot.Configurations.Language
{
    public static class LanguageManager
    {

        // Fields
        private static Dictionary<string, string> _translations;


        public static bool Initialize()
        {
            if (!Directory.Exists("Langs"))
                return false;

            string langFile = Path.Combine("Langs", $"{GlobalConfiguration.Instance.Lang}.lang");

            if (!File.Exists(langFile))
                return false;

            _translations = new Dictionary<string, string>();
            foreach (string line in File.ReadAllLines(langFile))
            {
                string[] translation = line.Split('|');

                if (_translations.ContainsKey(translation[0]))
                    continue;

                _translations.Add(translation[0], translation[1]);
            }

            return true;
        }

        public static string Translate(string key)
            => _translations?.ContainsKey(key) == true ? _translations[key] : key;

        public static string Translate(string key, params object[] @params)
        {
            if (_translations?.ContainsKey(key) == false)
                return key;

            return @params.Length == 0 ? _translations[key] : string.Format(_translations[key], @params);
        }

    }
}

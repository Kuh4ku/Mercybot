using System;
using System.Collections.Generic;
using System.Threading;
using MercyBot.Configurations.Language;

namespace MercyBot.Utility
{
    public class Randomize
    {

        // Fields
        private static int seed = Environment.TickCount;
        private static readonly ThreadLocal<Random> random = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));
        private static readonly object lockObj = new object();
        private static readonly List<string> loadingTexts = new List<string>()
        {
            LanguageManager.Translate("232"),
            LanguageManager.Translate("233"),
            LanguageManager.Translate("234"),
            LanguageManager.Translate("235"),
            LanguageManager.Translate("236")
        };


        public static int GetRandomInt(int min, int max)
        {
            lock (lockObj)
            {
                return min <= max
                ? random.Value.Next(min, max)
                : random.Value.Next(max, min);
            }
        }

        public static double GetRandomNumber()
        {
            lock (lockObj)
            {
                return random.Value.NextDouble();
            }
        }

        public static string GetRandomLoadingText()
            => loadingTexts[GetRandomInt(0, loadingTexts.Count)];

    }
}

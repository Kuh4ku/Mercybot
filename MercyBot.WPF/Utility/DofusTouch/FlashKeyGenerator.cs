using System;
using System.Text;

namespace MercyBot.Utility.DofusTouch
{
    public static class FlashKeyGenerator
    {
        
        public static string GetRandomFlashKey()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 20; i++)
            {
                sb.Append(GetRandomChar());
            }

            sb.Append(Checksum(sb.ToString()));
            return sb.ToString();
        }

        private static char GetRandomChar()
        {
            int n = (int)Math.Ceiling(Randomize.GetRandomNumber() * 100);

            if (n <= 40)
                return (char)(Math.Floor(Randomize.GetRandomNumber() * 26) + 65);

            if (n <= 80)
                return (char)(Math.Floor(Randomize.GetRandomNumber() * 26) + 97);

            return (char)(Math.Floor(Randomize.GetRandomNumber() * 26) + 48);
        }

        private static string Checksum(string s)
        {
            int r = 0;

            for (int i = 0; i < s.Length; i++)
            {
                r += (s[i]) % 16;
            }

            return (r % 16).ToString("X");
        }

    }
}

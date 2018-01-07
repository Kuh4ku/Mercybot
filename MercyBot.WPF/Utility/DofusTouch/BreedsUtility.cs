using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using MercyBot.Protocol.Data;

namespace MercyBot.Utility.DofusTouch
{
    public static class BreedsUtility
    {

        // Properties
        public static List<Breeds> Breeds { get; private set; }


        public static void Initialize()
        {
            Breeds = DataManager.GetList<Breeds>(Enumerable.Range(1, 15)).OrderBy(b => b.Id).ToList();
        }

        public static IEnumerable<string> GetBreedHeads(int breedId, int sex)
            => Enumerable.Range(1, 8).Select(o => $"https://ankama.akamaized.net/games/dofus-tablette/assets/{DTConstants.AssetsVersion}/gfx/cosmetics/{breedId}{sex}_{o}.png");

        public static Color[] GetBreedBaseColors(Breeds breed, int sex)
            => (sex == 0
                ? breed.MaleColors.Select(ParseIndexedColor)
                : breed.FemaleColors.Select(ParseIndexedColor)).ToArray();

        private static Color ParseIndexedColor(int indexedColor)
        {
            var index = (indexedColor & 0xF000000) >> 24;
            Console.WriteLine(index);
            var red = (byte)((indexedColor & 0xFF0000) >> 16);
            var green = (byte)((indexedColor & 0x00FF00) >> 8);
            var blue = (byte)(indexedColor & 0x0000FF);
            return Color.FromArgb(255, red, green, blue);
        }

        public static int GetIndexedColor(int index, Color color)
        {
            var result = 0;
            result |= (index & 0xF) << 24;
            result |= (color.R & 0xFF) << 16;
            result |= (color.G & 0xFF) << 8;
            result |= color.B & 0xFF;
            return result;
        }

        public static int GetCosmeticId(int breedId, bool sex, int headOrder)
            => (1 + (breedId - 1) * 8 * 2 + (sex ? 1 : 0) * 8) + headOrder;

    }
}

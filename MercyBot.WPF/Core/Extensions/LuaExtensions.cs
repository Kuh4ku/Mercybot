using MoonSharp.Interpreter;

namespace MercyBot.Core.Extensions
{
    public static class LuaExtensions
    {

        public static T GetOr<T>(this Table table, string key, DataType type, T orValue)
        {
            var flag = table.Get(key);

            if (flag.IsNil() || flag.Type != type)
                return orValue;

            try
            {
                return (T)flag.ToObject(typeof(T));
            }
            catch
            {
                return orValue;
            }
        }

    }
}

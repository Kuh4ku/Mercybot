using MercyBot.Core.Accounts.Scripts.Api;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MercyBot.Core.Accounts.Scripts.Managers
{
    public class LuaScriptManager : IDisposable
    {

        // Properties
        public Script Script { get; private set; }


        public void LoadFromFile(string filePath, Action beforeDoFile)
        {
            Script = new Script();
            beforeDoFile();
            Script.DoFile(filePath);
        }

        public IEnumerable<Table> GetFunctionEntries(string functionName)
        {
            var func = Script.Globals.Get(functionName);

            if (func.IsNil() || func.Type != DataType.Function)
                return null;

            var result = Script.Call(func);

            return result.Type != DataType.Table ? null : result.Table.Values.Where(f => f.Type == DataType.Table).Select(f => f.Table);
        }

        public T GetGlobalOr<T>(string key, DataType type, T orValue)
        {
            var global = Script.Globals.Get(key);

            if (global.IsNil() || global.Type != type)
                return orValue;

            try
            {
                return (T)global.ToObject(typeof(T));
            }
            catch
            {
                return orValue;
            }
        }

        public DynValue GetGlobalAsDynValue(string key) =>
            Script.Globals.Get(key);

        public T GetGlobalOr<T>(string key, T or)
            => HasGlobal(key) ? (T)Script.Globals[key] : or;

        public T GetGlobal<T>(string key)
            => HasGlobal(key) ? (T)Script.Globals[key] : default(T);

        public bool HasGlobal(string key)
            => Script.Globals[key] != null;

        public void SetGlobal(string key, object value)
            => Script.Globals[key] = value;

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }

                Script = null;

                disposedValue = true;
            }
        }

        ~LuaScriptManager() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

        public static void Initialize()
        {
            // Register all the types with [MoonSharpUserData] attribute
            UserData.RegisterAssembly();
        }

    }
}

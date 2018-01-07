using MercyBot.Core.Accounts;
using MercyBot.Protocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using MercyBot.Utility.Extensions;

namespace MercyBot.Core.Frames
{
    public static class FramesManager
    {

        // Fields
        private static Dictionary<string, List<MethodInfo>> _methods;


        public static void Initialize()
        {
            _methods = new Dictionary<string, List<MethodInfo>>();
            var fmnm = typeof(FramesManager).Namespace;

            // Function that checks if a method is a message handler (e.g. HandleMessageName(account, message)
            bool IsMethodValid(MethodInfo method)
                => method.IsPublic && method.IsStatic && method.ReturnType == typeof(Task);

            foreach (var type in Assembly.GetEntryAssembly().GetTypes())
            {
                if (type.Namespace == null || !type.IsPublic || !type.Namespace.StartsWith(fmnm))
                    continue;

                var methods = type.GetMethods();

                foreach (var method in methods.Where(IsMethodValid))
                {
                    var parameters = method.GetParameters();
                    if (parameters.Length != 2 || parameters[1].ParameterType.Name.Length < 8)
                        continue;

                    string messageName = parameters[1].ParameterType.Name;

                    if (!_methods.ContainsKey(messageName))
                        _methods.Add(messageName, new List<MethodInfo>());

                    _methods[messageName].Add(method);
                }
            }
        }

        public static void HandleMessage(Account account, Message message)
        {
            string msgName = message.GetType().Name;

            if (!_methods.ContainsKey(msgName))
                return;

            foreach (var method in _methods[msgName])
            {
                try
                {
                    (method.Invoke(null, new object[] {account, message}) as Task).ContinueWith(
                        c => c.Exception.InnerException.SendCrashReport(),
                        TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously);
                }
                catch
                {
                    account.Logger.LogError("FramesManager", $"Error while invoking method {method.Name}");
                }
            }
        }

    }
}

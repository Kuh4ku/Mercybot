using MercyBot.Core.Accounts;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MercyBot.Core.Commands
{
    public class CommandsManager : IDisposable
    {

        // Fields
        private Account _account;


        // Constructor
        public CommandsManager(Account account)
        {
            _account = account;
        }


        public async Task HandleInput(string input)
        {
            if (string.IsNullOrEmpty(input))
                return;

            // Command
            if (input[0] == '/')
            {
                await HandleCommand(input.Substring(1).Split(' ')).ConfigureAwait(false);
            }
            // Plain text
            else
            {
                await _account.Game.Chat.SendMessage(input).ConfigureAwait(false);
            }
        }

        private async Task HandleCommand(string[] input)
        {
            if (input.Length == 0)
                return;

            // If the command doesn't exist
            var handlers = CommandsHandler.GetCommandHandlers(input[0]);
            if (handlers == null)
                return;

            var args = input.Length > 1 ? input.Skip(1).ToArray() : new string[0];
            foreach (var handler in handlers)
            {
                var handlerParameters = handler.GetParameters();
                bool needsAccount = handlerParameters.Length > 0 ? handlerParameters[0].ParameterType == typeof(Account) : false;

                // Check if this handler can actually handle this input
                if (handlerParameters.Length - (needsAccount ? 1 : 0) > args.Length)
                    continue;

                // In case the handler doesn't need parameters
                if (handlerParameters.Length == 0)
                {
                    await (handler.Invoke(null, null) as Task).ConfigureAwait(false);
                    continue;
                }

                // Otherwise we need to execute the handler with the parameters he wants
                object[] parameters = new object[handler.GetParameters().Length];

                // If the handler needs the account (must be as the first parameter on the handler)
                if (handlerParameters[0].ParameterType == typeof(Account))
                {
                    parameters[0] = _account;
                }

                // Set the other parameters as strings
                for (int i = 1; i < handlerParameters.Length; i++)
                {
                    // Check for a remainder attribute
                    if (handlerParameters[i].GetCustomAttribute<RemainerAttribute>() != null)
                    {
                        parameters[i] = string.Join(" ", args.Skip(i - 1));
                        break;
                    }

                    // Otherwise continue setting them
                    parameters[i] = args[i - 1];
                }

                // Execute the handler
                await (handler.Invoke(null, parameters) as Task).ConfigureAwait(false);
            }
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                _account = null;
                disposedValue = true;
            }
        }

        ~CommandsManager() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

    }
}

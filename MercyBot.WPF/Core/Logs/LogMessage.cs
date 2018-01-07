using System;
using System.Text;

namespace MercyBot.Core.Logs
{
    public class LogMessage
    {

        // Properties
        public string Source { get; }
        public string Message { get; }
        public string Color { get; }
        public DateTime Time { get; }


        // Constructor
        public LogMessage(string source, string message, string color)
        {
            Source = source;
            Message = message;
            Color = color;
            Time = DateTime.Now;
        }


        public override string ToString()
        {
            var sb = new StringBuilder();

            var source = string.IsNullOrEmpty(Source) ? "" : $" [{Source}]";
            sb.Append($"[{Time:HH:mm:ss:ffff}]{source} {Message}");

            return sb.ToString();
        }

    }
}
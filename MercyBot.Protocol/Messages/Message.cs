using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MercyBot.Protocol.Messages
{
    public abstract class Message
    {

        // Properties
        [JsonIgnore]
        public string MessageType => GetType().Name;


        public string ToCall()
        {
            var callObj = new
            {
                call = MessageType.Replace("Message", "").ToCamelCase(),
                data = this
            };

            return SerializeWithCamelCase(callObj);
        }

        public string ToSendMessage()
        {
            var sendMessageObj = new
            {
                call = "sendMessage",
                data = new
                {
                    type = MessageType,
                    data = this
                }
            };

            return SerializeWithCamelCase(sendMessageObj);
        }

        private string SerializeWithCamelCase(object obj)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.None
            };

            return JsonConvert.SerializeObject(obj, settings);
        }

    }
}
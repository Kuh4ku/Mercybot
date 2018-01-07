using MercyBot.Protocol.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MercyBot.Protocol.Converters
{
    public class TypedPropertyConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                var array = (JArray)serializer.Deserialize(reader);
                var elementType = objectType.GetTypeInfo().GetGenericArguments().Single();
                Type genericListType = typeof(List<>).MakeGenericType(elementType);
                IList list = (IList)Activator.CreateInstance(genericListType);

                foreach (var token in array)
                {
                    var trueType = TypesBuilder.GetType(token.Value<string>("_type"));
                    list.Add(token.ToObject(trueType));
                }

                return list;
            }

            {
                var token = (JToken)serializer.Deserialize(reader);
                var trueType = TypesBuilder.GetType(token.Value<string>("_type"));
                return token.ToObject(trueType);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            
        }

    }
}

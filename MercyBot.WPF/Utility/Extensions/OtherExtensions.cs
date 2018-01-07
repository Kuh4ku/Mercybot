using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System;
using CrashReporterDotNET;
using System.IO;

namespace MercyBot.Utility.Extensions
{
    public static class OtherExtensions
    {

        public static async Task<JObject> ReadAsJsonAsync(this HttpContent content)
        {
            var txtContent = await content.ReadAsStringAsync().ConfigureAwait(false);
            var jObj = JObject.Parse(txtContent);
            return jObj;
        }

        public static T? ReadNullable<T>(this BinaryReader br, Func<T?> func) where T : struct
        {
            bool hasValue = br.ReadBoolean();
            return hasValue ? func() : null;
        }

        public static void WriteNullable<T>(this BinaryWriter bw, T? value) where T : struct
        {
            bw.Write(value.HasValue);
            if (value.HasValue)
            {
                bw.Write((dynamic)value.Value);
            }
        }

        public static void SendCrashReport(this Exception exception, string developperMessage = "")
        {
            var reportCrash = new ReportCrash
            {
                DeveloperMessage = developperMessage,
                ToEmail = "mercybot.mail@gmail.com",
                DoctorDumpSettings = new DoctorDumpSettings()
                {
                    ApplicationID = new Guid("2d91c39b-99f9-4eab-bd9f-a7730f2289d2")
                }
            };

            reportCrash.Send(exception);
        }

        public static byte[] GetAllBytes(this BinaryWriter writer)
        {
            var pos = writer.BaseStream.Position;

            var data = new byte[writer.BaseStream.Length];
            writer.BaseStream.Position = 0;
            writer.BaseStream.Read(data, 0, (int)writer.BaseStream.Length);

            writer.BaseStream.Position = pos;

            return data;
        }

    }
}
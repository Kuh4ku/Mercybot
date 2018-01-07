namespace MercyBot.Protocol.Messages
{
    public class RecaptchaRequestMessage : Message
    {

        public EnrichData EnrichData { get; set; }

    }

    public class EnrichData
    {

        public string Sitekey { get; set; }

    } 

}

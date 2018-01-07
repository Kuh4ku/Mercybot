namespace MercyBot.Protocol.Messages
{
    public class kpiStartSessionMessage : Message
    {

        // Properties
        public string AccountSessionId { get; set; }
        public bool IsSubscriber { get; set; }


        // Constructor
       public kpiStartSessionMessage(string accountSessionId = "", bool isSubscriber = false)
        {
            AccountSessionId = accountSessionId;
            IsSubscriber = isSubscriber;
        }

    }
}

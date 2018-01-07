namespace MercyBot.Server.Enums
{
    public enum LoginResults
    {
        UNAUTHORIZED = 0,
        NOT_FOUND = 1,
        BANNED = 2,
        AWAITING_ACTIVATION = 3,
        WRONG_PASSWORD = 4,
        TOO_MANY_INSTANCES = 5
    }
}

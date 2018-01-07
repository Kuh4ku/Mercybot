namespace MercyBot.Core.Accounts.InGame.Fights
{
    public enum SpellInabilityReasons
    {
        NONE = 0,
        TOO_MANY_LAUNCHS = 1,
        COOLDOWN = 2,
        ACTION_POINTS = 3,
        TOO_MANY_LAUNCHS_ON_CELL = 4,
        MAX_RANGE = 5,
        MIN_RANGE = 6,
        NOT_IN_LINE = 7,
        LINE_OF_SIGHT = 8,
        TOO_MANY_INVOCATIONS = 9,
        NEED_FREE_CELL = 10,
        NEED_TAKEN_CELL = 11,
        REQUIRED_STATE = 12,
        FORBIDDEN_STATE = 13,
        NOT_IN_DIAGONAL = 14,
        UNKNOWN = 15,
        NOT_IN_RANGE = 16
    }
}

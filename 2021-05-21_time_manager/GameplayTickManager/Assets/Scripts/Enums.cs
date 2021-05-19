namespace IdleStuff
{
    // +----------------------------------------------------------------------------
    // + Enum: UpdateIntervalType
    // +----------------------------------------------------------------------------
    public enum UpdateIntervalType: int
    {
        Requested = 32523,
        Set = 32524,
        Tick = 32525,
    }

    public static partial class UpdateIntervalTypeExtensions
    {
        public static bool IsRequested(this UpdateIntervalType entry)
        {
            return entry == UpdateIntervalType.Requested;
        }

        public static bool IsSet(this UpdateIntervalType entry)
        {
            return entry == UpdateIntervalType.Set;
        }

        public static bool IsTick(this UpdateIntervalType entry)
        {
            return entry == UpdateIntervalType.Tick;
        }
    }
}

namespace BerlinClockTest.Classes
{
    public class CustomTime
    {
        public short Hours { get; }
        public short Minutes { get; }
        public short Seconds { get; }

        public CustomTime(short hours, short minutes, short seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
    }
}
namespace BerlinClockTest.Classes.Converters.Abstract
{
    public interface ICustomTimeConverter
    {
        CustomTime FromString(string aTime);
    }
}
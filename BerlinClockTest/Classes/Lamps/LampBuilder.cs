using BerlinClockTest.Classes.Lamps.Abstract;
using BerlinClockTest.Classes.Lamps.Constants;

namespace BerlinClockTest.Classes.Lamps
{
    public class LampBuilder : ILampBuilder
    {
        public Lamp CreateRedLamp()
        {
            return new Lamp(LampColors.Red);
        }

        public Lamp CreateYellowLamp()
        {
            return new Lamp(LampColors.Yellow);
        }
    }
}
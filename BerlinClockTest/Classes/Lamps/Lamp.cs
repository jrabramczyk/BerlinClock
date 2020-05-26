using BerlinClockTest.Classes.Lamps.Constants;

namespace BerlinClockTest.Classes.Lamps
{
    public class Lamp
    {
        private const string LightOffColor = LampColors.TurnOff;
        private readonly string _lightOnColor;
        private bool _isLighting;

        public Lamp(string lightOnColor)
        {
            _lightOnColor = lightOnColor;
        }

        public void TurnOn(bool isTurnOn = true)
        {
            _isLighting = isTurnOn;
        }

        public override string ToString()
        {
            return _isLighting ? _lightOnColor : LightOffColor;
        }
    }
}
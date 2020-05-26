using System.Linq;
using System.Text;
using BerlinClockTest.Classes.Clocks.Abstract;
using BerlinClockTest.Classes.Lamps;
using BerlinClockTest.Classes.Lamps.Abstract;

namespace BerlinClockTest.Classes.Clocks
{
    public class BerlinClock : IClock
    {
        private readonly ILampBuilder _lampBuilder;
        private Lamp _blinkingLamp;
        private Lamp[] _5HoursLamps;
        private Lamp[] _1HourLamps;
        private Lamp[] _5MinutesLamps;
        private Lamp[] _1MinuteLamps;

        public BerlinClock(ILampBuilder lampBuilder)
        {
            _lampBuilder = lampBuilder;

            InitializeLamps();
        }

        private void InitializeLamps()
        {
            _blinkingLamp = _lampBuilder.CreateYellowLamp();

            _5HoursLamps = Enumerable.Range(1, 4).Select(x => _lampBuilder.CreateRedLamp()).ToArray();
            _1HourLamps = Enumerable.Range(1, 4).Select(x => _lampBuilder.CreateRedLamp()).ToArray();

            _5MinutesLamps = Enumerable.Range(1, 11)
                .Select(x => x % 3 == 0 ? _lampBuilder.CreateRedLamp() : _lampBuilder.CreateYellowLamp()).ToArray();

            _1MinuteLamps = Enumerable.Range(1, 4).Select(x => _lampBuilder.CreateYellowLamp()).ToArray();
        }

        public string DisplayTime(CustomTime time)
        {
            TurnOffAllLamps();

            SetBlinkingLamp(time);
            SetHourLamps(time);
            SetMinuteLamps(time);

            return DisplayTime();
        }

        private void TurnOffAllLamps()
        {
            _blinkingLamp.TurnOn(false);
            _5HoursLamps.ToList().ForEach(x => x.TurnOn(false));
            _1HourLamps.ToList().ForEach(x => x.TurnOn(false));
            _5MinutesLamps.ToList().ForEach(x => x.TurnOn(false));
            _1MinuteLamps.ToList().ForEach(x => x.TurnOn(false));
        }

        private void SetBlinkingLamp(in CustomTime time)
        {
            _blinkingLamp.TurnOn(time.Seconds % 2 == 0);
        }

        private void SetHourLamps(in CustomTime time)
        {
            #region turn on 5 hours lamps

            var quantityOfLampsToTurnOn = time.Hours / 5;
            for (int i = 0; i < quantityOfLampsToTurnOn; i++)
            {
                _5HoursLamps[i].TurnOn();
            }

            #endregion

            #region turn on 1 hour lamps

            quantityOfLampsToTurnOn = time.Hours % 5;
            for (int i = 0; i < quantityOfLampsToTurnOn; i++)
            {
                _1HourLamps[i].TurnOn();
            }

            #endregion
        }

        private void SetMinuteLamps(in CustomTime time)
        {
            #region turn on 5 minutes lamps

            var quantityOfLampsToTurnOn = time.Minutes / 5;
            for (int i = 0; i < quantityOfLampsToTurnOn; i++)
            {
                _5MinutesLamps[i].TurnOn();
            }

            #endregion

            #region turn on 1 minute laps

            quantityOfLampsToTurnOn = time.Minutes % 5;
            for (int i = 0; i < quantityOfLampsToTurnOn; i++)
            {
                _1MinuteLamps[i].TurnOn();
            }

            #endregion
        }

        private string DisplayTime()
        {
            var result = new StringBuilder();

            result.AppendLine(_blinkingLamp.ToString());

            result.AppendLine(string.Join("", _5HoursLamps.Select(x => x.ToString())));
            result.AppendLine(string.Join("", _1HourLamps.Select(x => x.ToString())));
            result.AppendLine(string.Join("", _5MinutesLamps.Select(x => x.ToString())));
            result.Append(string.Join("", _1MinuteLamps.Select(x => x.ToString())));

            return result.ToString();
        }
    }
}
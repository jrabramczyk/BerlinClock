using System;
using BerlinClockTest.Classes.Converters.Abstract;

namespace BerlinClockTest.Classes.Converters
{
    public class CustomTimeConverter : ICustomTimeConverter
    {
        public CustomTime FromString(string aTime)
        {
            if (!string.IsNullOrWhiteSpace(aTime))
            {
                var splitTime = aTime.Split(':');

                if (splitTime.Length == 3)
                {
                    try
                    {
                        var hours = short.Parse(splitTime[0]);
                        var minutes = short.Parse(splitTime[1]);
                        var seconds = short.Parse(splitTime[2]);

                        return new CustomTime(hours, minutes, seconds);
                    }
                    catch
                    {
                        throw new InvalidCastException($"Specified time: '{aTime}' can't be converted into TimeSpan." +
                                                       $"Please make sure you provide convertible format." +
                                                       $"Supported format is: 'HH:mm:ss'.");
                    }
                }
            }

            throw new InvalidCastException($"Specified time: '{aTime}' can't be converted into TimeSpan." +
                                           $"Please make sure you provide convertible format. " +
                                           $"Supported format is: 'HH:mm:ss'.");
        }
    }
}
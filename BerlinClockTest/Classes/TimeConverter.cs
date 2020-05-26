using Autofac;
using BerlinClockTest.Classes.Clocks.Abstract;
using BerlinClockTest.Classes.Converters.Abstract;

namespace BerlinClockTest.Classes
{
    public class TimeConverter 
    {
        private readonly IContainer _container;

        public TimeConverter()
        {
            //register all dependencies within the project 
            _container = DependencyRegister.Register();
        }

        public string ConvertTime(string aTime)
        {
            var timeConverter = _container.Resolve<ICustomTimeConverter>();
            var customTime = timeConverter.FromString(aTime);

            var clock = _container.Resolve<IClock>();

            return clock.DisplayTime(customTime);
        }
    }
}
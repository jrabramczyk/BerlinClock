using Autofac;
using BerlinClockTest.Classes.Clocks;
using BerlinClockTest.Classes.Clocks.Abstract;
using BerlinClockTest.Classes.Converters;
using BerlinClockTest.Classes.Converters.Abstract;
using BerlinClockTest.Classes.Lamps;
using BerlinClockTest.Classes.Lamps.Abstract;

namespace BerlinClockTest.Classes
{
    public class DependencyRegister
    {
        public static IContainer Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CustomTimeConverter>().As<ICustomTimeConverter>();
            builder.RegisterType<BerlinClock>().As<IClock>();
            builder.RegisterType<LampBuilder>().As<ILampBuilder>();

            return builder.Build();
        }
    }
}
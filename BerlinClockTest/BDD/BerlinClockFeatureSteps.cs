using BerlinClockTest.Classes;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BerlinClockTest.BDD
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private readonly TimeConverter berlinClock = new TimeConverter();
        private string _theTime;


        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            _theTime = time;
        }

        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(berlinClock.ConvertTime(_theTime), theExpectedBerlinClockOutput);
        }

    }
}

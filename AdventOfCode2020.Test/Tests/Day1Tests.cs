using AdventOfCode2020.Days;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Tests
{
    public class Day1Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day1(true);
        }

        [Test]
        public void FirstPart()
        {
            Assert.AreEqual("514579", _day.SolveFirstPart());
        }

        [Test]
        public void SecondPart()
        {
            Assert.AreEqual("241861950", _day.SolveSecondPart());
        }
    }
}

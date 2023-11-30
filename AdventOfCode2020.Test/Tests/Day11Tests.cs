using AdventOfCode2020.Days;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Tests
{
    public class Day11Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day11(true);
        }

        [Test]
        public void FirstPart()
        {
            Assert.AreEqual("37", _day.SolveFirstPart());
        }

        [Test]
        public void SecondPart()
        {
            Assert.AreEqual("26", _day.SolveSecondPart());
        }
    }
}

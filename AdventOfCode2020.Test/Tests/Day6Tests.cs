using AdventOfCode2020.Days;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Tests
{
    public class Day6Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day6(true);
        }

        [Test]
        public void FirstPart()
        {
            Assert.AreEqual("11", _day.SolveFirstPart());
        }

        [Test]
        public void SecondPart()
        {
            Assert.AreEqual("6", _day.SolveSecondPart());
        }
    }
}
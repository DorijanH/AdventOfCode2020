using AdventOfCode2020.Days;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Tests
{
    public class Day2Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day2(true);
        }

        [Test]
        public void FirstPart()
        {
            Assert.AreEqual("2", _day.SolveFirstPart());
        }

        [Test]
        public void SecondPart()
        {
            Assert.AreEqual("1", _day.SolveSecondPart());
        }
    }
}
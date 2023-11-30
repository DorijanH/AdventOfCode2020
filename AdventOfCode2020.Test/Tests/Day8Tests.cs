using AdventOfCode2020.Days;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Tests
{
    public class Day8Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day8(true);
        }

        [Test]
        public void FirstPart()
        {
            Assert.AreEqual("5", _day.SolveFirstPart());
        }

        [Test]
        public void SecondPart()
        {
            Assert.AreEqual("8", _day.SolveSecondPart());
        }
    }
}
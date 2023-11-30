using AdventOfCode2020.Days;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Tests
{
    public class Day4Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day4(true);
        }

        [Test]
        public void FirstPart()
        {
            Assert.AreEqual("2", _day.SolveFirstPart());
        }

        [Test]
        public void SecondPart()
        {
            Assert.AreEqual("2", _day.SolveSecondPart());
        }
    }
}
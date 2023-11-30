using AdventOfCode2020.Days;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Tests
{
    public class Day9Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day9(5, true);
        }

        [Test]
        public void FirstPart()
        {
            Assert.AreEqual("127", _day.SolveFirstPart());
        }

        [Test]
        public void SecondPart()
        {
            Assert.AreEqual("62", _day.SolveSecondPart());
        }
    }
}
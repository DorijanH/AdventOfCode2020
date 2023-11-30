using AdventOfCode2020.Days;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Tests
{
    public class Day7Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day7(true);
        }

        [Test]
        public void FirstPart()
        {
            Assert.AreEqual("4", _day.SolveFirstPart());
        }

        [Test]
        public void SecondPart()
        {
            Assert.AreEqual("32", _day.SolveSecondPart());
        }
    }
}
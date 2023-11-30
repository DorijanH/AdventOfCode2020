using AdventOfCode2020.Days;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Tests
{
    public class Day10Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day10(true);
        }

        [Test]
        public void FirstPart()
        {
            Assert.AreEqual("220", _day.SolveFirstPart());
        }

        [Test]
        public void SecondPart()
        {
            Assert.AreEqual("19208", _day.SolveSecondPart());
        }
    }
}

using AdventOfCode2020.Days;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Tests
{
    public class Day3Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day3(true);
        }

        [Test]
        public void FirstPart()
        {
            Assert.AreEqual("7", _day.SolveFirstPart());
        }

        [Test]
        public void SecondPart()
        {
            Assert.AreEqual("336", _day.SolveSecondPart());
        }
    }
}
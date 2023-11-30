using AdventOfCode2020.Days;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Tests
{
    public class Day5Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day5(true);
        }

        [Test]
        public void FirstPart()
        {
            Assert.AreEqual("820", _day.SolveFirstPart());
        }
    }
}
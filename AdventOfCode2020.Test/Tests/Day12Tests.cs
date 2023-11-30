using AdventOfCode2020.Days;
using NUnit.Framework;

namespace AdventOfCode2020.Test.Tests
{
    public class Day12Tests
    {
        private AdventDay _day;

        [SetUp]
        public void Setup()
        {
            _day = new Day12(true);
        }

        [Test]
        public void FirstPart()
        {
            Assert.AreEqual("25", _day.SolveFirstPart());
        }

        [Test]
        public void SecondPart()
        {
            
        }
    }
}

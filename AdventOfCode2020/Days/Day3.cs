using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020.Days
{
    public class Day3 : AdventDay
    {
        private readonly List<string> _inputLines;

        public Day3(bool isExample = false) : base(3, isExample)
        {
            _inputLines = new List<string>();

            LoadInput(InputStream);
        }

        public sealed override void LoadInput(StreamReader sr)
        {
            string line;
            while (!string.IsNullOrWhiteSpace(line = sr.ReadLine()))
            {
                _inputLines.Add(line);
            }
        }

        public override string SolveFirstPart()
        {
            var numberOfTrees = CountTrees(3, 1);
            return numberOfTrees.ToString();
        }

        public override string SolveSecondPart()
        {
            (int right, int down)[] slopes = {(1, 1), (3, 1), (5, 1), (7, 1), (1, 2)};

            var multipliedAnswer = 1L;

            foreach (var slope in slopes)
            {
                var numberOfTrees = CountTrees(slope.right, slope.down);
                multipliedAnswer *= numberOfTrees;
            }

            Console.WriteLine($"Multiplied number of trees on all of our slopes: {multipliedAnswer}");
            return multipliedAnswer.ToString();
        }

        private int CountTrees(int right, int down)
        {
            var numberOfTrees = 0;

            for (int i = down, xOffset = right; i < _inputLines.Count; i += down, xOffset += right)
            {
                var currentLine = _inputLines[i];

                //extend the line if our offset is out of bounds
                while (xOffset >= currentLine.Length)
                {
                    currentLine += currentLine;
                }

                if (currentLine[xOffset] == '#') numberOfTrees++;
            }

            Console.WriteLine($"Current slope: ({right}, {down})");
            Console.WriteLine($"Number of trees on our slope path: {numberOfTrees}");

            return numberOfTrees;
        }
    }
}
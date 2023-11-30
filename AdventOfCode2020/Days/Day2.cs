using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Days
{
    public class Day2 : AdventDay
    {
        private readonly List<string> _inputLines;

        public Day2(bool isExample = false) : base(2, isExample)
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
            var numberOfValidPasswords = 0;

            foreach (var line in _inputLines)
            {
                var splitLine = line.Split(new[] { '-', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

                var lowestNumber = int.Parse(splitLine[0]);
                var highestNumber = int.Parse(splitLine[1]);
                var letter = char.Parse(splitLine[2]);
                var password = splitLine[3];

                var letterCount = password.Count(c => c == letter);
                if (letterCount >= lowestNumber && letterCount <= highestNumber)
                {
                    numberOfValidPasswords++;
                }
            }

            Console.WriteLine($"Number of valid passwords: {numberOfValidPasswords}");
            return numberOfValidPasswords.ToString();
        }

        public override string SolveSecondPart()
        {
            var numberOfValidPasswords = 0;

            foreach (var line in _inputLines)
            {
                var splitLine = line.Split(new[] { '-', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

                var firstPosition = int.Parse(splitLine[0]) - 1;    // accounting for zero-index
                var secondPosition = int.Parse(splitLine[1]) - 1;   // accounting for zero-index
                var letter = char.Parse(splitLine[2]);
                var password = splitLine[3];

                if (password[firstPosition] == letter ^ password[secondPosition] == letter)
                {
                    numberOfValidPasswords++;
                }
            }

            Console.WriteLine($"Number of valid passwords: {numberOfValidPasswords}");
            return numberOfValidPasswords.ToString();
        }
    }
}
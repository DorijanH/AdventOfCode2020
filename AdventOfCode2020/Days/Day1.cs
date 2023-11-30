using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020.Days
{
    public class Day1 : AdventDay
    {
        private readonly List<int> _inputNumbers;

        public Day1(bool isExample = false) : base(1, isExample)
        {
            _inputNumbers = new List<int>();

            LoadInput(InputStream);
        }

        public sealed override void LoadInput(StreamReader sr)
        {
            string line;
            while (!string.IsNullOrWhiteSpace(line = sr.ReadLine()))
            {
                _inputNumbers.Add(int.Parse(line));
            }
        }

        public override string SolveFirstPart()
        {
            for (var i = 0; i < _inputNumbers.Count; i++)
            {
                for (var j = i + 1; j < _inputNumbers.Count; j++)
                {
                    var x = _inputNumbers[i];
                    var y = _inputNumbers[j];

                    if (x + y == 2020)
                    {
                        var multiplication = x * y;

                        Console.WriteLine($"Numbers found were: {x} and {y}. Their sum is: {x + y}");
                        Console.WriteLine($"Their multiplication is: {multiplication}");
                        return multiplication.ToString();
                    }
                }
            }

            return string.Empty;
        }

        public override string SolveSecondPart()
        {
            for (var i = 0; i < _inputNumbers.Count; i++)
            {
                for (var j = i + 1; j < _inputNumbers.Count; j++)
                {
                    for (var k = j + 1; k < _inputNumbers.Count; k++)
                    {
                        var x = _inputNumbers[i];
                        var y = _inputNumbers[j];
                        var z = _inputNumbers[k];

                        if (x + y + z == 2020)
                        {
                            var multiplication = x * y * z;

                            Console.WriteLine($"Numbers found were: {x}, {y} and {z}. Their sum is: {x + y + z}");
                            Console.WriteLine($"Their multiplication is: {multiplication}");
                            return multiplication.ToString();
                        }
                    }
                }
            }

            return string.Empty;
        }
    }
}
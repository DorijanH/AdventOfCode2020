using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Days
{
    public class Day6 : AdventDay
    {
        private readonly List<string> _inputGroups;

        public Day6(bool isExample = false) : base(6, isExample)
        {
            _inputGroups = new List<string>();

            LoadInput(InputStream);
        }

        public sealed override void LoadInput(StreamReader sr)
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var currentLine = line + ' ';

                string nextLine;
                while (!string.IsNullOrWhiteSpace(nextLine = sr.ReadLine()))
                {
                    currentLine += nextLine + ' ';
                }

                _inputGroups.Add(currentLine);
            }
        }

        public override string SolveFirstPart()
        {
            var sumOfAnswers = 0;

            foreach (var group in _inputGroups)
            {
                var groupAnswers = group.Except(new[] {' '});
                var distinctAnswers = groupAnswers.Distinct();
                var count = distinctAnswers.Count();

                sumOfAnswers += count;
            }

            var rj = _inputGroups.Select(g => g.Except(new[] {' '})).Distinct().Sum(x => x.Count());

            Console.WriteLine($"Sum of answer counts is {sumOfAnswers}");
            return sumOfAnswers.ToString();
        }

        public override string SolveSecondPart()
        {
            var sumOfAnswers = 0;

            foreach (var group in _inputGroups)
            {
                var peopleAnswers = group.Trim().Split(' ');

                var count = 0;
                for (var i = 'a'; i <= 'z'; i++)
                {
                    if (peopleAnswers.All(a => a.Contains(i)))
                    {
                        count++;
                    }
                }
                sumOfAnswers += count;
            }

            Console.WriteLine($"Sum of answer counts is {sumOfAnswers}");
            return sumOfAnswers.ToString();
        }
    }
}
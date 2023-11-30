using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Days
{
    public class Day10 : AdventDay
    {
        private List<int> _inputJolts;

        private int _maxJoltDifference;

        public Day10(bool isExample = false) : base(10, isExample)
        {
            _maxJoltDifference = 3;

            LoadInput(InputStream);
        }

        public sealed override void LoadInput(StreamReader sr)
        {
            _inputJolts = InputStream.ReadToEnd().Split("\r\n").Select(int.Parse).OrderBy(j => j).ToList();

            var adapterJolt = _inputJolts.Max() + _maxJoltDifference;
            _inputJolts.Add(adapterJolt);
        }

        public override string SolveFirstPart()
        {
            var oneJoltDif = 0;
            var threeJoltDif = 0;
            var currentJolts = 0;

            foreach (var jolt in _inputJolts)
            {
                var joltDif = jolt - currentJolts;

                if (joltDif <= _maxJoltDifference && joltDif == 1)
                {
                    oneJoltDif++;
                    currentJolts = jolt;
                }
                else if (joltDif <= _maxJoltDifference && joltDif == 3)
                {
                    threeJoltDif++;
                    currentJolts = jolt;
                }
                else
                {
                    currentJolts = jolt;
                }
            }

            var result = oneJoltDif * threeJoltDif;

            Console.WriteLine($"Got the chain! {oneJoltDif} differences of 1 jolt and {threeJoltDif} differences of 3 jolts.");
            Console.WriteLine($"Their multiplication result is {result}");
            return result.ToString();
        }

        public override string SolveSecondPart()
        {
            // there is at least 1 possibility
            var possibilites = new Dictionary<int, long> {{0, 1}};

            foreach (var jolt in _inputJolts)
            {
                var posibility = 0L;

                for (var i = 1; i <= _maxJoltDifference; i++)
                {
                    if (possibilites.ContainsKey(jolt - i))
                    {
                        posibility += possibilites[jolt - i];
                    }
                }

                possibilites.Add(jolt, posibility);
            }

            Console.WriteLine($"Number of possibilites: {possibilites[_inputJolts[^1]]}");
            return possibilites[_inputJolts[^1]].ToString();
        }

    }
}
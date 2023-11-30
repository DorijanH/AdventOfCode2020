using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Days
{
    public class Day7 : AdventDay
    {
        private readonly Dictionary<string, string[]> _bagMappings;

        public Day7(bool isExample = false) : base(7, isExample)
        {
            _bagMappings = new Dictionary<string, string[]>();

            LoadInput(InputStream);
        }

        public sealed override void LoadInput(StreamReader sr)
        {
            string line;
            while (!string.IsNullOrWhiteSpace(line = sr.ReadLine()))
            {
                var splitLine = line.Split("contain", StringSplitOptions.TrimEntries);
                var containerBag = splitLine[0].Replace("bags", "bag");
                var rest = splitLine[1].Replace("bags", "bag").Replace(".", "");

                if (rest.Contains(", "))
                {
                    var containedBags = rest.Split(", ", StringSplitOptions.TrimEntries);

                    _bagMappings.Add(containerBag, containedBags);
                }
                else if (rest.Contains("no other bag"))
                {
                    _bagMappings.Add(containerBag, new []{""});
                }
                else
                {
                    var containedBag = rest;

                    _bagMappings.Add(containerBag, new[] {containedBag});
                }
            }
        }

        public override string SolveFirstPart()
        {
            var ourBag = "shiny gold bag";
            
            var bagsThatCanCarry = new List<string>();

            bool changeHappened = true;
            while (changeHappened)
            {
                changeHappened = false;

                foreach (var bag in _bagMappings)
                {
                    var bagNames = bag.Value[0] == string.Empty ? bag.Value : bag.Value.Select(b => b.Split(' ', 2)[1]);

                    if (!bagsThatCanCarry.Contains(bag.Key) && (bagNames.Contains(ourBag) || bagsThatCanCarry.Any(btcc => bagNames.Contains(btcc))))
                    {
                        bagsThatCanCarry.Add(bag.Key);
                        changeHappened = true;
                    }
                }
            }

            Console.WriteLine($"Search finished. Number of bags that can carry our {ourBag} is: {bagsThatCanCarry.Count}");
            return bagsThatCanCarry.Count.ToString();
        }

        public override string SolveSecondPart()
        {
            var ourBag = "shiny gold bag";
            var containedInOurBag = _bagMappings[ourBag];

            var count = 0;
            foreach (var containedBag in containedInOurBag)
            {
                var bagAmount = int.Parse(containedBag.Split(' ')[0]);

                var countInnerBags = CalculateAmountOfBags(containedBag);
                count += (bagAmount + bagAmount * countInnerBags);
            }
            
            Console.WriteLine($"Search finished. Number of bags that we can carry in our {ourBag} is: {count}");
            return count.ToString();
        }

        private int CalculateAmountOfBags(string bag)
        {
            var bagName = bag.Split(' ', 2)[1];
            

            if (_bagMappings[bagName][0] == string.Empty)
            {
                return 0;
            }

            var count = 0;
            foreach (var innerBag in _bagMappings[bagName])
            {
                var amountOfBags = int.Parse(innerBag.Split(' ')[0]);

                var innerBags = CalculateAmountOfBags(innerBag);

                count += (innerBags == 0 ? amountOfBags : amountOfBags * (innerBags + 1));
            }

            return count;


        }
    }
}
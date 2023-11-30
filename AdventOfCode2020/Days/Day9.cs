using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Days
{
    public class Day9 : AdventDay
    {
        private long[] _inputNumbers;

        private readonly int _preambleLength;

        public Day9(int preambleLength, bool isExample = false) : base(9, isExample)
        {
            _preambleLength = preambleLength;

            LoadInput(InputStream);
        }

        public sealed override void LoadInput(StreamReader sr)
        {
            _inputNumbers = sr.ReadToEnd().Split("\r\n").Select(long.Parse)
                .ToArray();
        }

        public override string SolveFirstPart()
        {
            var invalidNumber = FindInvalidNumber();

            Console.WriteLine($"First number that stands out is: {invalidNumber}");
            return invalidNumber.ToString();
        }

        public override string SolveSecondPart()
        {
            var invalidNumber = FindInvalidNumber();

            var encryptionWeakness = 0L;

            for (var i = 0; i < _inputNumbers.Length; i++)
            {
                var endIndex = CheckWithStartIndex(i, invalidNumber);

                if (endIndex != -1)
                {
                    Console.WriteLine($"First index of our set is {i} and the last index is {endIndex}");

                    var set = _inputNumbers[i..(endIndex + 1)];
                    
                    encryptionWeakness = set.Min() + set.Max();
                    break;
                }
            }

            Console.WriteLine($"Found encryption weakness of {encryptionWeakness}");
            return encryptionWeakness.ToString();
        }

        private bool CheckIfValid(int numberIndex, int historyLength)
        {
            var numberToCheck = _inputNumbers[numberIndex];

            var firstIndex = numberIndex - historyLength;
            var numbersBefore = _inputNumbers[firstIndex..numberIndex];
            
            for (var i = 0; i < numbersBefore.Length; i++)
            {
                for (var j = i + 1; j < numbersBefore.Length; j++)
                {
                    var x = numbersBefore[i];
                    var y = numbersBefore[j];

                    if (x + y == numberToCheck) return true;
                }
            }

            return false;
        }

        private long FindInvalidNumber()
        {
            var invalidNumber = 0L;

            for (var i = _preambleLength; i < _inputNumbers.Length; i++)
            {
                if (!CheckIfValid(i, _preambleLength))
                {
                    invalidNumber = _inputNumbers[i];
                    break;
                }
            }

            return invalidNumber;
        }
        private int CheckWithStartIndex(int start, long invalidNumber)
        {
            var sumSoFar = _inputNumbers[start];

            var endIndex = start;
            for (var i = endIndex + 1; i < _inputNumbers.Length; i++)
            {
                var currentNumber = _inputNumbers[i];

                if(sumSoFar + currentNumber < invalidNumber)
                {
                    sumSoFar += currentNumber;
                }
                else if (sumSoFar + currentNumber == invalidNumber)
                {
                    endIndex = i;
                    break;
                }
                else
                {
                    return -1;
                }
            }

            return endIndex;
        }
    }
}
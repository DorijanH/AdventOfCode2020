using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day5 : AdventDay
    {
        private readonly Dictionary<char, int> _mapping = new Dictionary<char, int>
        {
            {'F', 0}, {'B', 1}, {'R', 1}, {'L', 0}
        };

        private readonly List<string> _inputLines;
        private readonly List<int> _occupiedSeats;

        private int _planeRows = 128;
        private int _planeColumns = 8;

        public Day5(bool isExample = false) : base(5, isExample)
        {
            _inputLines = new List<string>();
            _occupiedSeats = new List<int>();

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
            foreach (var encodedSeat in _inputLines)
            {
                var row = DecodeString(encodedSeat.Substring(0, 7));
                var column = DecodeString(encodedSeat.Substring(7, 3));

                var seatID = row * _planeColumns + column;

                _occupiedSeats.Add(seatID);
            }

            var highestSeatID = _occupiedSeats.Max();

            Console.WriteLine($"Highest seatID found is: {highestSeatID}");
            return highestSeatID.ToString();
        }

        public override string SolveSecondPart()
        {
            var planeCapacity = _planeRows * _planeColumns;

            for (var i = 0; i < planeCapacity; i++)
            {
                if (!_occupiedSeats.Contains(i) && _occupiedSeats.Contains(i - 1) && _occupiedSeats.Contains(i + 1))
                {
                    Console.WriteLine($"ID of my seat is: {i}");
                    return i.ToString();
                }
            }

            return string.Empty;
        }

        private int DecodeString(string encodedString)
        {
            var sb = new StringBuilder();

            foreach (var letter in encodedString)
            {
                sb.Append(_mapping[letter]);
            }

            return Convert.ToInt32(sb.ToString(), 2);
        }
    }
}
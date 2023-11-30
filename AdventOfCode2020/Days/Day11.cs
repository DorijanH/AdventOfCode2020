using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Days
{
    public class Day11 : AdventDay
    {
        private List<char[]> _inputSeats;

        public Day11(bool isExample = false) : base(11, isExample)
        {
            LoadInput(InputStream);
        }

        public sealed override void LoadInput(StreamReader sr)
        {
            _inputSeats = InputStream.ReadToEnd().Split("\r\n").Select(i => i.ToCharArray()).ToList();
        }

        public override string SolveFirstPart()
        {
            var changes = new List<(int, int)>();

            do
            {
                changes.Clear();
                
                for (var row = 0; row < _inputSeats.Count; row++)
                {
                    for (var column = 0; column < _inputSeats[row].Length; column++)
                    {
                        var seatLabel = _inputSeats[row][column];

                        if (seatLabel == '.') continue;

                        var adjacentOccupiedSeats = ImmediatelyAdjacent(row, column);

                        if (seatLabel == 'L' && adjacentOccupiedSeats == 0) changes.Add((row, column));
                        else if (seatLabel == '#' && adjacentOccupiedSeats >= 4) changes.Add((row, column));
                    }
                }

                UpdateLayout(changes);

            } while (changes.Any());

            var occupiedSeats = _inputSeats.Select(r => r.Count(s => s == '#')).Sum();

            Console.WriteLine($"There are {occupiedSeats} occupied seats!");
            return occupiedSeats.ToString();
        }

        public override string SolveSecondPart()
        {
            LoadInput(InputStream);


            var changes = new List<(int, int)>();

            do
            {
                changes.Clear();

                for (var row = 0; row < _inputSeats.Count; row++)
                {
                    for (var column = 0; column < _inputSeats[row].Length; column++)
                    {
                        var seatLabel = _inputSeats[row][column];

                        if (seatLabel == '.') continue;

                        var adjacentOccupiedSeats = FirstInDirection(row, column);

                        if (seatLabel == 'L' && adjacentOccupiedSeats == 0) changes.Add((row, column));
                        else if (seatLabel == '#' && adjacentOccupiedSeats >= 5) changes.Add((row, column));
                    }
                }

                UpdateLayout(changes);

            } while (changes.Any());

            var occupiedSeats = _inputSeats.Select(r => r.Count(s => s == '#')).Sum();

            Console.WriteLine($"There are {occupiedSeats} occupied seats!");
            return occupiedSeats.ToString();
        }

        

        private void UpdateLayout(List<(int row, int column)> changes)
        {
            foreach (var change in changes)
            {
                if (_inputSeats[change.row][change.column] == 'L') _inputSeats[change.row][change.column] = '#';
                else if (_inputSeats[change.row][change.column] == '#') _inputSeats[change.row][change.column] = 'L';
            }
        }

        private int ImmediatelyAdjacent(int row, int column)
        {
            var result = 0;

            for (var i = row - 1; i <= row + 1; i++)
            {
                for (var j = column - 1; j <= column + 1; j++)
                {
                    if (i < 0 || i >= _inputSeats.Count) continue;

                    if (j < 0 || j >= _inputSeats[i].Length) continue;

                    if (i == row && j == column) continue;

                    if (_inputSeats[i][j] == '#') result++;
                }
            }

            return result;
        }

        private int FirstInDirection(int row, int column)
        {
            var result = 0;

            // left horizontal check
            for (var j = column - 1; j > -1; j--)
            {
                if (_inputSeats[row][j] == 'L') break;

                if (_inputSeats[row][j] == '#')
                {
                    result++;
                    break;
                }
            }

            // right horizontal check
            for (var j = column + 1; j < _inputSeats[row].Length; j++)
            {
                if (_inputSeats[row][j] == 'L') break;

                if (_inputSeats[row][j] == '#')
                {
                    result++;
                    break;
                }
            }

            // up vertical check
            for (var i = row - 1; i > -1; i--)
            {
                if (_inputSeats[i][column] == 'L') break;

                if (_inputSeats[i][column] == '#')
                {
                    result++;
                    break;
                }
            }

            // down vertical check
            for (var i = row + 1; i < _inputSeats.Count; i++)
            {
                if (_inputSeats[i][column] == 'L') break;

                if (_inputSeats[i][column] == '#')
                {
                    result++;
                    break;
                }
            }

            // up \ check
            for (int i = row - 1, j = column - 1; i > -1 && j > -1; i--, j--)
            {
                if (_inputSeats[i][j] == 'L') break;

                if (_inputSeats[i][j] == '#')
                {
                    result++;
                    break;
                }
            }

            // down \ check
            for (int i = row + 1, j = column + 1; i < _inputSeats.Count && j < _inputSeats[i].Length; i++, j++)
            {
                if (_inputSeats[i][j] == 'L') break;

                if (_inputSeats[i][j] == '#')
                {
                    result++;
                    break;
                }
            }

            // up / check
            for (int i = row - 1, j = column + 1; i > -1 && j < _inputSeats[i].Length; i--, j++)
            {
                if (_inputSeats[i][j] == 'L') break;

                if (_inputSeats[i][j] == '#')
                {
                    result++;
                    break;
                }
            }

            // down / check
            for (int i = row + 1, j = column - 1; i < _inputSeats.Count && j > -1; i++, j--)
            {
                if (_inputSeats[i][j] == 'L') break;

                if (_inputSeats[i][j] == '#')
                {
                    result++;
                    break;
                }
            }

            return result;
        }

    }
}
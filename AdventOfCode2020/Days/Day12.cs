using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Days
{
    public class Day12 : AdventDay
    {
        private List<(char, int)> _inputNavigation;

        private readonly Dictionary<char, int> _boatCoordinates = new Dictionary<char, int>
        {
            {'N', 0}, {'S', 0}, {'E', 0}, {'W', 0}
        };

        private readonly Dictionary<char, int> _wpCoordinates = new Dictionary<char, int>
        {
            {'N', 1}, {'S', 0}, {'E', 10}, {'W', 0}
        };

        private readonly char[] _validDirections = {'E', 'S', 'W', 'N'};
        
        private int _currentDirection;

        public Day12(bool isExample = false) : base(12, isExample)
        {
            LoadInput(InputStream);
        }

        public sealed override void LoadInput(StreamReader sr)
        {
            _inputNavigation = InputStream.ReadToEnd().Split("\r\n")
                .Select(n => (n[0], int.Parse(n[1..])))
                .ToList();
        }

        public override string SolveFirstPart()
        {
            foreach (var (direction, value) in _inputNavigation)
            {
                switch (direction)
                {
                    case 'N':
                        _boatCoordinates[direction] += value;
                        break;
                    case 'E':
                        _boatCoordinates[direction] += value;
                        break;
                    case 'S':
                        _boatCoordinates[direction] += value;
                        break;
                    case 'W':
                        _boatCoordinates[direction] += value;
                        break;
                    case 'F':
                        _boatCoordinates[_validDirections[_currentDirection]] += value;
                        break;

                    case 'L':
                        _currentDirection = Modulo(_currentDirection - value / 90, 4);
                        break;

                    case 'R':
                        _currentDirection = Modulo(_currentDirection + value / 90, 4);
                        break;
                }
            }

            var distance = Math.Abs(_boatCoordinates['E'] - _boatCoordinates['W']) +
                           Math.Abs(_boatCoordinates['N'] - _boatCoordinates['S']);

            Console.WriteLine($"Ship's Manhattan distance is {distance}");

            return distance.ToString();
        }

        public override string SolveSecondPart()
        {
            foreach (var (direction, value) in _inputNavigation)
            {
                switch (direction)
                {
                    case 'N':
                        _wpCoordinates[direction] += value;
                        break;
                    case 'E':
                        _wpCoordinates[direction] += value;
                        break;
                    case 'S':
                        _wpCoordinates[direction] += value;
                        break;
                    case 'W':
                        _wpCoordinates[direction] += value;
                        break;
                    case 'F':
                        MoveShip(value);
                        break;

                    case 'L':
                        MoveWpLeft(value);
                        _currentDirection = Modulo(_currentDirection - value / 90, 4);
                        break;

                    case 'R':
                        _currentDirection = Modulo(_currentDirection + value / 90, 4);
                        break;
                }
            }


        }

        private void MoveWpLeft(int value)
        {
            
        }

        private void MoveShip(int value)
        {
            foreach (var dir in _validDirections)
            {
                _boatCoordinates[dir] += value * _wpCoordinates[dir];
            }
        }

        private int Modulo(int a, int b)
        {
            return (a % b + b) % b;
        }


    }
}
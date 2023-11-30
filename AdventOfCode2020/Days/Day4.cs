using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Days
{
    public class Day4 : AdventDay
    {
        private readonly List<string> _inputPassports;

        private readonly string[] _requiredFields = {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};

        public Day4(bool isExample = false) : base(4, isExample)
        {
            _inputPassports = new List<string>();

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

                _inputPassports.Add(currentLine);
            }
        }

        public override string SolveFirstPart()
        {
            var numberOfValidPassports = 0;

            foreach (var passport in _inputPassports)
            {
                var keyValuePairs = passport.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var keys = keyValuePairs.Select(p => p.Split(':')[0]).ToList();

                if (_requiredFields.All(f => keys.Contains(f)))
                {
                    numberOfValidPassports++;
                }
            }

            Console.WriteLine($"Number of valid passports: {numberOfValidPassports}");
            return numberOfValidPassports.ToString();
        }

        public override string SolveSecondPart()
        {
            var numberOfValidPassports = 0;

            foreach (var passport in _inputPassports)
            {
                var keyValuePairs = passport.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var keys = keyValuePairs.Select(p => p.Split(':')[0]).ToList();

                if (_requiredFields.All(f => keys.Contains(f)) && ValidValidations(keyValuePairs))
                {
                    numberOfValidPassports++;
                }
            }

            Console.WriteLine($"Number of valid passports: {numberOfValidPassports}");
            return numberOfValidPassports.ToString();
        }

        private bool ValidValidations(string[] keyValuePairs)
        {
            var keys = keyValuePairs.Select(p => p.Split(':')[0]).ToList();
            var values = keyValuePairs.Select(p => p.Split(':')[1]).ToList();

            bool valid = true;
            for (var i = 0; i < keys.Count; i++)
            {
                var value = values[i];

                switch (keys[i])
                {
                    case "byr":
                        valid = value.Length == 4 && (int.Parse(value) >= 1920 && int.Parse(value) <= 2002);
                        break;
                    case "iyr":
                        valid = value.Length == 4 && (int.Parse(value) >= 2010 && int.Parse(value) <= 2020);
                        break;
                    case "eyr":
                        valid = value.Length == 4 && (int.Parse(value) >= 2020 && int.Parse(value) <= 2030);
                        break;
                    case "hgt":
                        var split = Regex.Matches(value, @"\D+|\d+").Select(m => m.Value).ToArray();

                        if (split.Length < 2)
                        {
                            valid = false;
                            break;
                        }

                        var number = int.Parse(split[0]);
                        var suffix = split[1];

                        if (suffix != "cm" && suffix != "in")
                        {
                            valid = false;
                            break;
                        }

                        if (suffix == "cm" && (number >= 150 && number <= 193))
                        {
                            valid = true;
                            break;
                        }

                        if (suffix == "in" && (number >= 59 && number <= 76))
                        {
                            valid = true;
                            break;
                        }

                        valid = false;
                        break;
                    case "hcl":
                        valid = Regex.IsMatch(value, @"^#[0-9a-f]{6}");
                        break;
                    case "ecl":
                        var validEcls = new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

                        valid = validEcls.Contains(value);
                        break;
                    case "pid":
                        valid = value.Length == 9;
                        break;
                }

                if (!valid) break;
            }

            return valid;
        }
    }
}
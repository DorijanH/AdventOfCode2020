using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020.Days
{
    public class Day8 : AdventDay
    {
        private readonly List<string> _instructions;

        private int _accumulator;

        public Day8(bool isExample = false) : base(8, isExample)
        {
            _instructions = new List<string>();
            _accumulator = 0;

            LoadInput(InputStream);
        }

        public sealed override void LoadInput(StreamReader sr)
        {
            _instructions.AddRange(sr.ReadToEnd().Split("\r\n"));
        }

        public override string SolveFirstPart()
        {
            EvaluateInstructions();

            Console.WriteLine($"Value of accumulator global variable before loop is: {_accumulator}");

            return _accumulator.ToString();
        }

        public override string SolveSecondPart()
        {
            for (var i = 0; i < _instructions.Count; i++)
            {
                var initialOperation = _instructions[i].Split(' ')[0];

                var newOperation = string.Empty;
                if (initialOperation == "jmp")
                {
                    newOperation = "nop";
                    _instructions[i] = _instructions[i].Replace(initialOperation, newOperation);

                }
                else if (initialOperation == "nop")
                {
                    newOperation = "jmp";
                    _instructions[i] = _instructions[i].Replace(initialOperation, newOperation);
                }
                else
                {
                    continue;
                }

                var loopExists = EvaluateInstructions();
                if (loopExists)
                {
                    _instructions[i] = _instructions[i].Replace(newOperation, initialOperation);
                }
                else
                {
                    Console.WriteLine($"There wasn't a loop. Accumulator is: {_accumulator}");
                    return _accumulator.ToString();
                }
            }

            return string.Empty;
        }

        private int ValueToAdd(string argument)
        {
            var argumentSign = argument[0];
            var argumentNumber = int.Parse(argument[1..]);

            return argumentSign == '+' ? argumentNumber : -argumentNumber;
        }

        private bool EvaluateInstructions()
        {
            _accumulator = 0;

            var evaluatedInstructionIndexes = new List<int>();

            var instructionIndex = 0;

            while (instructionIndex < _instructions.Count)
            {
                var instructionParts = _instructions[instructionIndex].Split(' ');
                var operation = instructionParts[0];
                var argument = instructionParts[1];

                if (evaluatedInstructionIndexes.Contains(instructionIndex))
                {
                    return true;
                }

                evaluatedInstructionIndexes.Add(instructionIndex);

                switch (operation)
                {
                    case "nop":
                        instructionIndex++;
                        break;
                    case "jmp":
                        instructionIndex += ValueToAdd(argument);
                        break;
                    case "acc":
                        _accumulator += ValueToAdd(argument);
                        instructionIndex++;
                        break;
                }
            }

            return false;
        }
    }
}
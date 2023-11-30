using System;
using System.IO;

namespace AdventOfCode2020
{
    public abstract class AdventDay
    {
        public StreamReader InputStream => new StreamReader(InputPath);

        private string InputPath =>
            IsExample ? $@"../../../../AdventOfCode2020/Inputs/Day{Day}Example.txt" : $@"../../../Inputs/Day{Day}.txt";

        public bool IsExample { get; set; }

        public int Day { get; }

        protected AdventDay(int day, bool isExample)
        {
            Day = day;
            IsExample = isExample;
        }

        public void Solve()
        {
            Console.WriteLine("FIRST PART:");
            SolveFirstPart();

            Console.WriteLine();

            Console.WriteLine("SECOND PART:");
            SolveSecondPart();
        }

        public abstract void LoadInput(StreamReader sr);

        public abstract string SolveFirstPart();

        public abstract string SolveSecondPart();
    }
}

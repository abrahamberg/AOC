using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Application;

namespace AdventOfCode._2020
{
    internal class _15 : Solution
    {
        public _15(IEnumerable<string> inputs, VersionEnum version) : base(inputs, version)
        {
        }

        protected override string SolverA(IEnumerable<string> inputs)
        {
            var list = new List<Num>();
            var lastSpoken = 0L;
            var seeds = inputs.First().Split(",").Select(long.Parse).ToArray();
            for (var i = 0; i < 2020; i++)
            {
                if (i < seeds.Length)
                {
                    lastSpoken = seeds[i];
                    list.Add(new Num(lastSpoken, i));

                    continue;
                }

                var current = NextNumber();
                var currentNum = list.FirstOrDefault(x => x.Face == current);
                if (currentNum is null) list.Add(new Num(current, i));
                else currentNum.Called(i);


                lastSpoken = current;
            }

            long NextNumber()
            {
                var last = list.First(x => x.Face == lastSpoken);
                if (last.BeforeLastTurn == -1) return 0;
                return last.LastTurn - last.BeforeLastTurn;
            }

            return lastSpoken.ToString();
        }

        protected override string SolverB(IEnumerable<string> inputs)
        {

            var list = new Dictionary<int, int>();
            var seeds = inputs.First().Split(",").Select(int.Parse).ToArray();
            var lastSpoken = 0;
            for (var i = 0; i < seeds.Length; i++)
            {
                if (i > 0) list.Add(lastSpoken, i);
                lastSpoken = seeds[i];
            }

            for (var i = seeds.Length; i < 30000000; i++)
            {
                var next = list.ContainsKey(lastSpoken) ? i - list[lastSpoken] : 0;
                list[lastSpoken]=i;
                lastSpoken = next;
            }

            return lastSpoken.ToString();
        }

        private class Num
        {
            public Num(long face, long turn)
            {
                Face = face;
                LastTurn = turn;
                BeforeLastTurn = -1;
            }

            public long Face { get; }
            public long LastTurn { get; private set; }
            public long BeforeLastTurn { get; set; }

            public void Called(long turn)
            {
                BeforeLastTurn = LastTurn;
                LastTurn = turn;
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Application;

namespace AdventOfCode._2020
{
    public class _05 : Solution
    {
        public _05(IEnumerable<string> inputs, VersionEnum version) : base(inputs, version)
        {
        }

        protected override string SolverA(IEnumerable<string> inputs)
        {
            return inputs.Max(x => new Seat(x).GetSitNumber()).ToString();
        }

        protected override string SolverB(IEnumerable<string> inputs)
        {
            var taken = inputs.Select(x => new Seat(x).GetSitNumber()).ToArray();

            var all = from row in Enumerable.Range(1, 127)
                from column in Enumerable.Range(0, 8)
                select row * 8 + column;


            return all.First(x => 
                !taken.Contains(x) 
                && taken.Contains(x + 1) 
                && taken.Contains(x - 1))
                .ToString();
        }


        private class Seat
        {
            public Seat(string spacePartition)
            {
                var rows = Enumerable.Range(0, 128).ToList();
                var seats = Enumerable.Range(0, 8).ToList();

                for (var i = 0; i < 7; i++) rows = spacePartition[i] == 'F' ? GetLower(rows) : GetHeigher(rows);
                for (var i = 7; i < 10; i++) seats = spacePartition[i] == 'L' ? GetLower(seats) : GetHeigher(seats);
                Row = rows.FirstOrDefault();
                Column = seats.FirstOrDefault();
            }

            public int Row { get; }
            public int Column { get; }

            private static List<int> GetLower(List<int> enumerable)
            {
                var avrage = enumerable.Average(x => x);
                return enumerable.Where(x => x < avrage).ToList();
            }

            private static List<int> GetHeigher(List<int> enumerable)
            {
                var avrage = enumerable.Average(x => x);
                return enumerable.Where(x => x > avrage).ToList();
            }

            public int GetSitNumber()
            {
                return Row * 8 + Column;
            }
        }
    }
}
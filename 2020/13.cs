using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Application;

namespace AdventOfCode._2020
{
    internal class _13 : Solution
    {
        public _13(IEnumerable<string> inputs, VersionEnum version) : base(inputs, version)
        {
        }

        protected override string SolverA(IEnumerable<string> inputs)
        {
            var all = inputs.ToArray();
            var ids = all[1].Split(',').Where(x => x != "x").Select(int.Parse);
            var time = int.Parse(all[0]);
            var arrivalTimes = ids.Select(x => new KeyValuePair<int, int>(x, x - time % x)).ToList();
            var (key, value) = arrivalTimes.Aggregate((x, y) => x.Value < y.Value ? x : y);
            return (key * value).ToString();
        }

        protected override string SolverB(IEnumerable<string> inputs)
        {
            var all = inputs.ToArray();
            var ids = all[1].Split(',');
            var buses = new List<KeyValuePair<int, int>>();

            for (var i = 0; i < ids.Length; i++)
                if (ids[i] != "x")
                    buses.Add(new KeyValuePair<int, int>(int.Parse(ids[i]), i));


            long start = buses[0].Key;
            var seed = start;

            foreach (var (id, difference) in buses)
            {
                long arrival;
                for (arrival = start + difference; arrival % id != 0; arrival += seed)
                { }
                start = arrival - difference;

                
                long nextArrival;
                for (nextArrival = arrival + seed; nextArrival % id != 0; nextArrival += seed)
                { }
                seed = nextArrival - arrival;
                       
            }

            return start.ToString();
        }
    }
}
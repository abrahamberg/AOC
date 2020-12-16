using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Application;

namespace AdventOfCode._2020
{
    internal class _16 : Solution
    {
        private List<Field> _fieldes;
        private List<int> _myTicket;
        private List<List<int>> _tickets;


        //TODO Constructor runs after methods, because they are called from base  
        public _16(IEnumerable<string> inputs, VersionEnum version) : base(inputs, version)
        { }

        

        protected override string SolverA(IEnumerable<string> inputs)
        {
            Init(inputs);
            var validRange = _fieldes.SelectMany(x => x.Acceptable).Distinct().ToArray();
            var allNumbers = _tickets.SelectMany(x => x).ToArray();
            var invalid = allNumbers.Where(x => !validRange.Contains(x)).ToArray();


            return invalid.Sum().ToString();
        }

        protected override string SolverB(IEnumerable<string> inputs)
        {
            Init(inputs);
            var validRange = _fieldes.SelectMany(x => x.Acceptable).Distinct().ToArray();
            var validTickets = (
                    from ticket in _tickets
                    let inValid = ticket.Any(x => !validRange.Contains(x))
                    where !inValid
                    select ticket)
                .ToList();


            var ticketLengh = validTickets.First().Count;

            for (var i = 0; i < ticketLengh; i++)
            {
                var cloumn = validTickets.Select(x => x[i]).Distinct().ToArray();
                var maching = _fieldes.Where(x => x.Acceptable.Intersect(cloumn).Count() == cloumn.Count()).ToList();
                foreach (var field in maching) field.PossibleIndexs.Add(i);
            }

            var sorted = _fieldes.OrderBy(x => x.PossibleIndexs.Count).ToList();
            foreach (var field in sorted)
            {
                var inx = field.PossibleIndexs.First();
                foreach (var innerField in sorted.Where(f => f != field)) innerField.PossibleIndexs.Remove(inx);
            }

            var departures = sorted.Where(f => f.Name.StartsWith("departure")).ToList();


            return departures.Aggregate<Field, long>(1, (current, field) =>
                    current * _myTicket[field.PossibleIndexs.First()])
                .ToString();
        }

        //read above why it is not placed in constructor 
        private void Init(IEnumerable<string> inputs)
        {
            _fieldes = new List<Field>();
            _tickets = new List<List<int>>();
            _myTicket = new List<int>();

            var phase = 0;
            foreach (var input in inputs)
            {
                if (input.Contains("your ticket:"))
                {
                    phase = 1;
                    continue;
                }

                if (input.Contains("nearby tickets:"))
                {
                    phase = 2;
                    continue;
                }

                if (string.IsNullOrWhiteSpace(input)) continue;

                if (phase == 0)
                {
                    var sp1 = input.Split(":");
                    var sp2 = sp1[1].Split("or");
                    var f = new Field(sp1[0].Trim());
                    foreach (var r in sp2)
                    {
                        var sp3 = r.Split("-");
                        f.AddRange(int.Parse(sp3[0]), int.Parse(sp3[1]));
                    }

                    _fieldes.Add(f);
                    continue;
                }

                if (phase == 1)
                {
                    _myTicket = input.Split(',').Select(int.Parse).ToList();
                    continue;
                }

                if (phase == 2)
                {
                    _tickets.Add(input.Split(',').Select(int.Parse).ToList());
                }
            }
        }


        private class Field
        {
            public Field(string name)
            {
                Name = name;
                Acceptable = new List<int>();
                PossibleIndexs = new List<int>();
            }


            public string Name { get; }
            public List<int> Acceptable { get; }
            public List<int> PossibleIndexs { get; }

            public void AddRange(int start, int end)
            {
                Acceptable.AddRange(Enumerable.Range(start, end - start + 1));
            }

        }
    }
}
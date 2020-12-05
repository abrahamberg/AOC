using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Application;

namespace AdventOfCode._2020
{
    public class _02 : Solution
    {
        public _02(IEnumerable<string> inputs, VersionEnum version) : base(inputs, version)
        {
        }

        protected override string SolverA(IEnumerable<string> inputs)
        {
            var count = inputs.Select(input => new Policy(input))
                .Count(policy => policy.PassCountPolicy());

            return count.ToString();
        }

        protected override string SolverB(IEnumerable<string> inputs)
        {
            var count = inputs.Select(input => new Policy(input))
                .Count(policy => policy.PassPositionPolicy());

            return count.ToString();
        }



        private class Policy
        {
            private readonly char _char;
            private readonly int _end;

            private readonly int _start;
            private readonly string _word;

            public Policy(string input)
            {
                var split = input.Split(' ');
                _start = int.Parse(split[0].Split('-')[0]);
                _end = int.Parse(split[0].Split('-')[1]);
                _char = split[1][0];
                _word = split[2];
            }

            public bool PassCountPolicy()
            {
                return _word.Split(_char).Length >= _start + 1 && _word.Split(_char).Length <= _end + 1;
            }

            public bool PassPositionPolicy()
            {
                var isInFirstPlace = _word[_start - 1] == _char && _word[_end - 1] != _char;
                var isInSecondPlace = _word[_start - 1] != _char && _word[_end - 1] == _char;

                return isInFirstPlace || isInSecondPlace;
            }
        }
    }
}
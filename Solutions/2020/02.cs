using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions._2020
{
    public class _02_A : Solution
    {
        public _02_A(IEnumerable<string> inputs) : base(inputs){ }

        protected override string Solver()
        {
            var count = Inputs.Select(input => new Policy(input))
                .Count(policy => policy.PassCountPolicy());

            return count.ToString();
        }
    }

    public class _02_B : Solution
    {
        public _02_B(IEnumerable<string> inputs) : base(inputs) { }

        protected override string Solver()
        {
            var count = Inputs.Select(input => new Policy(input))
                .Count(policy => policy.PassPositionPolicy());

            return count.ToString();
        }
    }

    internal class Policy
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
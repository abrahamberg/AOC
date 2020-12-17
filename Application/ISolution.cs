using System.Collections.Generic;

namespace AdventOfCode.Application
{
    public interface  ISolution
    {
        public string Puzzle1(IReadOnlyList<string> inputs);
        public string Puzzle2(IReadOnlyList<string> inputs);
    }
}
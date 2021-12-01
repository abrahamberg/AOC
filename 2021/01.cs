using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Application;

namespace AdventOfCode._2021
{
    class _01 : ISolution
    {
        public string Puzzle1(IReadOnlyList<string> inputs)
        {
            var intList = inputs.Select(x => int.Parse(x)).ToArray();
            var count = intList.Where((x, idx) => idx == 0 || x > intList[idx - 1]).Count() - 1;
            return count.ToString();
        }

        public string Puzzle2(IReadOnlyList<string> inputs)
        {
            var intList = inputs.Select(x => int.Parse(x)).ToArray();
            var treeList = new List<int>();
            for (int i = 0; (i < intList.Length - 2); i++)
                treeList.Add(intList[i]+ intList[i+1]+ intList[i+2]);

            var count = treeList.Where((x, idx) => idx == 0 || x > treeList[idx - 1]).Count() - 1;
            return count.ToString();
        }
    }
}

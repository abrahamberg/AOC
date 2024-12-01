using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using AdventOfCode.Application;

namespace AdventOfCode._2024
{
    public class _01 : ISolution
    {
        public string Puzzle1(IReadOnlyList<string> inputs)
        {
            var lines = inputs.Select(inp => inp.Split("   ")).ToList();
            var list1 = lines.Select(exp => int.Parse(exp[0])).ToList();
            list1.Sort();   
            var list2 = lines.Select(exp => int.Parse(exp[1])).ToList();
            list2.Sort();

            var sum = new List<int>();

            while (list1.Count > 0)
            {
                int difference = list1[0] - list2[0];
                sum.Add(Math.Abs(difference));
                list1.RemoveAt(0);
                list2.RemoveAt(0);
            }

            var total = sum.Aggregate((a, b) => a + b); 

            return total.ToString();
        }

        public string Puzzle2(IReadOnlyList<string> inputs)
        {
            var lines = inputs.Select(inp => inp.Split("   ")).ToArray();
            var list1 = lines.Select(exp => int.Parse(exp[0])).ToArray();
            var list2 = lines.Select(exp => int.Parse(exp[1])).ToArray();

            var sum = new List<BigInteger>();

            foreach (var i in list1){
             sum.Add(i * list2.Count(x => x == i));
            }

            var total = sum.Aggregate((a, b) => a + b); 

            return total.ToString();
        }
    }
}
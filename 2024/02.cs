using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using AdventOfCode.Application;

namespace AdventOfCode._2024;



public class _02 : ISolution
{
    private bool IsSafe(int[] n)
    {

        bool assending = n[1] - n[0] > 0;
        var copy = assending ?
            n.OrderBy(x => x).ToArray() :
            n.OrderByDescending(x => x).ToArray();
        var correctOrder = copy.SequenceEqual(n);

        for (int i = 1; i < n.Length; i++)
        {
            var diff = Math.Abs(n[i] - n[i - 1]);
            if (diff > 3 || diff == 0) return false;
        }

        return correctOrder;
    }

    public string Puzzle1(IReadOnlyList<string> inputs)
    {
        var lines = inputs.Select(inp => inp.Split(' ')).ToArray();
        int safe = 0;
        foreach (var line in lines)
        {
            var numbers = line.Select(int.Parse).ToArray();
            if (IsSafe(numbers)) safe++;
        }

        return safe.ToString();
    }



    public string Puzzle2(IReadOnlyList<string> inputs)
    {
        var lines = inputs.Select(inp => inp.Split(' ')).ToArray();
        int safe = 0;
        foreach (var line in lines)
        {
            var numbers = line.Select(int.Parse).ToArray();
            var isSafe = IsSafe(numbers);
            if (isSafe) safe++;
            else if (SecondChase(numbers)) safe++;

        }

        bool SecondChase(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var copy = numbers.ToList();
                copy.RemoveAt(i);
                if (IsSafe(copy.ToArray()))
                {
                    return true;
                }
            }
            return false;
        }

        return safe.ToString();
    }

   
}

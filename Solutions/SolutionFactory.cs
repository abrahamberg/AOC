using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Helpers;
using Ardalis.GuardClauses;

namespace AdventOfCode.Solutions
{
    public static class SolutionFactory
    {
        public static Solution Create(PuzzleName puzzleName, string puzzleVersion, IEnumerable<string> inputs)
        {
            Guard.Against.Null(puzzleName, nameof(puzzleName));
            Guard.Against.Null(puzzleVersion, nameof(puzzleVersion));

         

            var className = $@"AdventOfCode.Solutions._{puzzleName.Year}._{puzzleName.Day}_{puzzleVersion}";
            var t = Type.GetType(className);

            if (t is null)
                throw new NotImplementedException($"{className} does not exits");

            return (Solution) Activator.CreateInstance(t, inputs);
            ;
        }
    }
}
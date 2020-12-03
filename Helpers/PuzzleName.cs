using System;
using Ardalis.GuardClauses;

namespace AdventOfCode.Helpers
{
    public class PuzzleName
    {
        public PuzzleName(string name)
        {
            Guard.Against.Null(name, nameof(name));
            if (name.CountChars('-') != 1)
                throw new ArgumentException("The puzzle name should be formatted as yyyy-dd  ex. 2020-15");

            var nameSplit = name.Split('-');
            Year = nameSplit[0];
            Day = nameSplit[1];

        }

        public string Year { get; }
        public string Day { get; }
    }
}
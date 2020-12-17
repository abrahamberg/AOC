using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Application;

namespace AdventOfCode._2020
{
    public class _04 : ISolution
    {
        public string Puzzle1(IReadOnlyList<string> inputs)
        {
            return Looper.CountValid(inputs.ToList(),
                    inputLines => new Passport(inputLines).FieldsAreValid())
                .ToString();
        }

        public string Puzzle2(IReadOnlyList<string> inputs)
        {
            return Looper.CountValid(inputs,
                    inputLines => new Passport(inputLines).ContentsAreValid())
                .ToString();
        }






        private static class Looper
        {
            internal static int CountValid(IEnumerable<string> inputs, Func<string, bool> validate)
            {
                return string.Join(" ",
                        inputs.Select(x => string.IsNullOrWhiteSpace(x) ? "\n" : x))
                    .Split("\n")
                    .Count(validate);
            }
        }


        private class Passport
        {
            private readonly Dictionary<string, string> _passInfo;

            public Passport(string inputLines)
            {
                _passInfo = inputLines.Trim().Split(' ')
                    .Select(value => value.Split(':'))
                    .ToDictionary(pair => pair[0], pair => pair[1]);
            }


            public bool FieldsAreValid()
            {
                return _passInfo.Count switch
                {
                    8 => true,
                    7 when !_passInfo.Keys.Contains("cid") => true,
                    _ => false
                };
            }

            public bool ContentsAreValid()
            {
                if (!FieldsAreValid())
                    return false;

                foreach (var (key, value) in _passInfo)
                    switch (key)
                    {
                        case "byr":
                            if (!value.CheckValidNumberInRange(1920, 2002))
                                return false;
                            break;
                        case "iyr":
                            if (!value.CheckValidNumberInRange(2010, 2020))
                                return false;
                            break;
                        case "eyr":
                            if (!value.CheckValidNumberInRange(2020, 2030))
                                return false;
                            break;
                        case "hgt":
                            if (!ValidateHeight(value))
                                return false;
                            break;
                        case "hcl":
                            if (!ValidateColor(value))
                                return false;
                            break;

                        case "ecl":
                            if (!ValidateEyeColor(value))
                                return false;
                            break;
                        case "pid":
                            if (!ValidatePassportId(value))
                                return false;
                            break;
                    }

                return true;
            }

            private static bool ValidatePassportId(string infoValue)
            {
                var rx = new Regex(@"^\d{9}$");
                return rx.IsMatch(infoValue);
            }

            private static bool ValidateColor(string infoValue)
            {
                var rx = new Regex(@"^#[0-9a-fA-F]{6}$");
                return rx.IsMatch(infoValue);
            }

            private static bool ValidateEyeColor(string infoValue)
            {
                const string colors = "amb blu brn gry grn hzl oth";
                return colors.Contains(infoValue);
            }

            private static bool ValidateHeight(string infoValue)
            {
                if (infoValue.Contains("cm"))
                {
                    infoValue = infoValue.Replace("cm", "");
                    return infoValue.CheckValidNumberInRange(150, 193);
                }

                if (infoValue.Contains("in"))
                {
                    infoValue = infoValue.Replace("in", "");
                    return infoValue.CheckValidNumberInRange(59, 76);
                }

                return false;
            }
        }
    }
}
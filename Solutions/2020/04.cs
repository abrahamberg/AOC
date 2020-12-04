using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions._2020
{
    public class _04_A : Solution
    {
        public _04_A(IEnumerable<string> inputs) : base(inputs)
        {
        }

        protected override string Solver()
        {
            return Looper.CountValid(Inputs.ToList(), inputLines =>
            {
                var passport = new Passport(inputLines);
                return passport.FieldsAreValid();
            }).ToString();
        }
    }

    public class _04_B : Solution
    {
        public _04_B(IEnumerable<string> inputs) : base(inputs)
        {
        }

        protected override string Solver()
        {
            return Looper.CountValid(Inputs.ToList(), inputLines =>
            {
                var passport = new Passport(inputLines);
                return passport.ContentsAreValid();
            }).ToString();

        }
    }

    internal static class Looper
    {
        internal static int CountValid(IReadOnlyList<string> inputs, Func<string, bool> validate )
        {
            var countValid = 0;
            var inputLines = "";
            foreach (var input in inputs)
                if (string.IsNullOrWhiteSpace(input))
                {
                    if (validate(inputLines))
                        countValid ++;
                    inputLines = "";
                }
                else
                {
                    inputLines += " " + input;

                    if (input == inputs.Last() && validate(inputLines)) countValid++ ;
                }

            return countValid;
        }
    }

    internal class Passport
    {
        private readonly Dictionary<string, string> _passInfo;

        public Passport(string inputLines)
        {
            inputLines = inputLines.Trim();
            _passInfo = inputLines.Split(' ')
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
                        if (!CheckValidNumber(value, 1920, 2002))
                            return false;
                        break;
                    case "iyr":
                        if (!CheckValidNumber(value, 2010, 2020))
                            return false;
                        break;
                    case "eyr":
                        if (!CheckValidNumber(value, 2020, 2030))
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
                        if (!ValidatePassportID(value))
                            return false;
                        break;
                }

            return true;
        }

        private bool ValidatePassportID(string infoValue)
        {
            var rx = new Regex(@"^\d{9}$");
            return rx.IsMatch(infoValue);
        }

        private bool ValidateColor(string infoValue)
        {
            var rx = new Regex(@"^#[0-9a-fA-F]{6}$");
            return rx.IsMatch(infoValue);
        }

        private bool ValidateEyeColor(string infoValue)
        {
            const string colors = "amb blu brn gry grn hzl oth";
            return colors.Contains(infoValue);
        }

        private static bool ValidateHeight(string infoValue)
        {
            if (infoValue.Contains("cm"))
            {
                infoValue = infoValue.Replace("cm", "");
                return CheckValidNumber(infoValue, 150, 193);
            }

            if (infoValue.Contains("in"))
            {
                infoValue = infoValue.Replace("in", "");
                return CheckValidNumber(infoValue, 59, 76);
            }

            return false;
        }

        private static bool CheckValidNumber(string s, int start, int end)
        {
            if (!int.TryParse(s, out var i))
                return false;
            return i >= start && i <= end;
        }
    }
}
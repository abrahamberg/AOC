using System.Collections.Generic;
using AdventOfCode.Application;

namespace AdventOfCode._2020
{
    public class _01 : ISolution
    {
        public string Puzzle1(IReadOnlyList<string> inputs)
        {
            var expenses = new List<int>();
            foreach (var input in inputs)
            {
                var currentExpense = int.Parse(input);
                expenses.Add(currentExpense);

                var expense = expenses.Find(exp => exp + currentExpense == 2020);
                if (expense != 0)
                    return (expense * currentExpense).ToString();
            }

            return null;
        }

        public string Puzzle2(IReadOnlyList<string> inputs)
        {
            var expenses = new List<int>();
            foreach (var input in inputs)
            {
                var currentExpense = int.Parse(input);
                expenses.Add(currentExpense);
                foreach (var expense in expenses)
                {
                    var expense2 = expenses.Find(exp => exp + expense + currentExpense == 2020);
                    if (expense2 != 0)
                        return (expense * expense2 * currentExpense).ToString();
                }
            }

            return null;
        }
    }
}
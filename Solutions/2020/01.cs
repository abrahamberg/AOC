using System.Collections.Generic;

namespace AdventOfCode.Solutions._2020
{
    public class _01_A : Solution
    {
        public _01_A(IEnumerable<string> inputs) : base(inputs)
        {
        }

        protected override string Solver()
        {
            var expenses = new List<int>();
            foreach (var input in Inputs)
            {
                var currentExpense = int.Parse(input);
                expenses.Add(currentExpense);

                var expense = expenses.Find(exp => exp + currentExpense == 2020);
                if (expense != 0)
                    return (expense * currentExpense).ToString();
            }

            return null;
        }
    }

    public class _01_B : Solution
    {
        public _01_B(IEnumerable<string> inputs) : base(inputs)
        {
        }

        protected override string Solver()
        {
            var expenses = new List<int>();
            foreach (var input in Inputs)
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
            ;
        }
    }
}
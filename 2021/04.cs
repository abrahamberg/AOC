using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Application;

namespace AdventOfCode._2021
{
    class _04 : ISolution
    {
        public string Puzzle1(IReadOnlyList<string> inputs)
        {
           
            var numbers = inputs[0].Split(',');
            var matrixs = new List<List<string[]>>();
          
            for (int i = 1; i < inputs.Count; i++)
            {
                
                if (inputs[i].Length == 0) 
                {
                    matrixs.Add(new List<string[]>());
                    continue;
                };
                matrixs.LastOrDefault().Add(inputs[i].Trim().Replace("  "," ").Split(' '));
            }

            (List<string[]> martix, string[] selectedNumbs, string lastNumber, string[] revieledNumbs) winner= (null,null,null,null);
            var revieledNumbers = new List<string>();
         
            for (int i = 0; i < numbers.Length; i++)
            {
                revieledNumbers.Add(numbers[i]);
                if (i < 5) continue;

                foreach (var matrix in matrixs)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (matrix[j].All(x => revieledNumbers.Contains(x))) //row
                        {
                            winner = (matrix, matrix[j], numbers[i], revieledNumbers.ToArray());
                            break;
                        }
                        if (matrix.Select(x => x[j]).All(x => revieledNumbers.Contains(x))) //cloumn
                        {
                            winner = (matrix, matrix.Select(x => x[j]).ToArray(), numbers[i], revieledNumbers.ToArray());
                            break;
                        }
                    }
                    if (winner.martix != null)
                        break;
                }
                if (winner.martix != null)
                    break;
            }

            var unmarkeds = new List<string>();
            foreach (var row in winner.martix)
                unmarkeds.AddRange(row.Where(x => !winner.revieledNumbs.Contains(x)));

            var sum = unmarkeds.Distinct().Select(x => int.Parse(x)).Aggregate(0, (current, member) => current + member);


            return (sum * int.Parse(winner.lastNumber)).ToString();
        }

       

        public string Puzzle2(IReadOnlyList<string> inputs)
        {

            var numbers = inputs[0].Split(',');
            var matrixs = new List<List<string[]>>();

            for (int i = 1; i < inputs.Count; i++)
            {

                if (inputs[i].Length == 0)
                {
                    matrixs.Add(new List<string[]>());
                    continue;
                };
                matrixs.LastOrDefault().Add(inputs[i].Trim().Replace("  ", " ").Split(' '));
            }

           List<(List<string[]> martix, string[] selectedNumbs, string lastNumber, string[] revieledNumbs, int winingIndex)>   boardsWiningStates = new();
            var revieledNumbers = new List<string>();

            for (int i = 0; i < numbers.Length; i++)
            {
               
                revieledNumbers.Add(numbers[i]);
                if (i < 5) continue;

                FindWinningMatrix(matrixs);

                void FindWinningMatrix(List<List<string[]>> remainingMatrixes)
                {
                    (List<string[]> martix, string[] selectedNumbs, string lastNumber, string[] revieledNumbs, int winingIndex) winningState = (null, null, null, null, -1);
                    foreach (var matrix in remainingMatrixes)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (matrix[j].All(x => revieledNumbers.Contains(x))) //row
                            {
                                winningState = (matrix, matrix[j], numbers[i], revieledNumbers.ToArray(), i);
                                boardsWiningStates.Add(winningState);
                                break;
                            }
                            if (matrix.Select(x => x[j]).All(x => revieledNumbers.Contains(x))) //cloumn
                            {
                                winningState = (matrix, matrix.Select(x => x[j]).ToArray(), numbers[i], revieledNumbers.ToArray(), i);
                                boardsWiningStates.Add(winningState);
                                break;
                            }
                        }
                        if (winningState.martix != null)
                            break;
                    }
                    if (winningState.martix != null)
                    {
                        remainingMatrixes.Remove(winningState.martix);
                        FindWinningMatrix(remainingMatrixes);
                    }
                       

                }

            }

            var looser = boardsWiningStates.First(x=> x.winingIndex == boardsWiningStates.Max(y => y.winingIndex));
            var unmarkeds = new List<string>();
            foreach (var row in looser.martix)
                unmarkeds.AddRange(row.Where(x => !looser.revieledNumbs.Contains(x)));

            var sum = unmarkeds.Distinct().Select(x => int.Parse(x)).Aggregate(0, (current, member) => current + member);


            return (sum * int.Parse(looser.lastNumber)).ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MinCoins
{
    public class CoinChange
    {

        public void FindPossibleCombinations(int sumOfCombination, int target, int position, List<int> combination, int[] coins)
        {
            for (int i = position; i < coins.Length; i++)
            {
                int coin = coins[i];
                sumOfCombination += coin;

                if (sumOfCombination > target)
                {
                    return;
                }

                combination.Add(coin);
                if (sumOfCombination.Equals(target))
                {
                    Console.WriteLine(combination);
                    combination.Remove(combination.Count - 1);
                    return;
                }

                FindPossibleCombinations(sumOfCombination, target, position, combination, coins);
                combination.Remove(combination.Count - 1);
                sumOfCombination -= coin;
                position++;
            }
        }

        public List<List<int>> FindPossibleCombinationsDynamicProgramming(int target, int[]coins)
        {
            var grid = new Cell[coins.Length + 1,target + 1];

            for (var i = 0; i <= coins.Length; i++)
            {
                grid[i,0] = new Cell();
            }

            for (var i = 1; i <= target; i++)
            {
                grid[0,i] = new Cell();
            }

            for(var i = 1; i <= coins.Length; i++)
            {
                var coin = coins[i - 1];
                for (int j = 1; j <= target; j++)
                {
                    var cell = new Cell();
                    var previousCoinCell = grid[i - 1, j];
                    cell.Combinations = previousCoinCell.Combinations;

                    if (j.Equals(coin))
                    {
                        cell.AddCombinations(new List<int>(coin));
                    }
                    else if (coin < j)
                    {
                        var prevCell = grid[i, j - coin];
                        foreach(var list in prevCell.Combinations)
                        {
                            var combination = new List<int>(list) {coin};
                            cell.AddCombinations(combination);
                        }
                    }
                    grid[i, j] = cell;
                }
            }
            return grid[coins.Length,target].Combinations;
        }
    }
}

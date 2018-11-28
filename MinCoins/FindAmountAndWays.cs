using System;
using System.Collections.Generic;
using System.Text;

namespace MinCoins
{
    class FindAmountAndWays
    {
        public static int MinCoins(int[] coins, int input)
        {
            var array = new int[input + 1];
            var amountOfCoins = coins.Length;
            array[0] = 0;

            for (var i = 1; i <= input; i++)
            {
                array[i] = Int32.MaxValue;
            }

            for (var i = 1; i <= input; i++)
            {
                for (var j = 0; j < amountOfCoins; j++)
                {
                    if (coins[j] <= i)
                    {
                        var subRes = array[i - coins[j]];
                        if (subRes != Int32.MaxValue && subRes + 1 < array[i])
                        {
                            array[i] = subRes + 1;
                        }
                    }
                }
            }

            var output = "";
            output = output + Environment.NewLine;
            for (var i = 1; i <= input; i++)
            {
                output = output + array[i];
                output += "|";
            }
            Console.WriteLine(output);
            Console.ReadKey();
            return array[input];
        }

        public int CountWays(int[] coins, int input)
        {
            var array = new int[input + 1];
            var amountOfCoins = coins.Length;
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }

            array[0] = 1;

            for (var i = 0; i < amountOfCoins; i++)
            {
                for (var j = coins[i]; j <= input; j++)
                {
                    array[j] += array[j - coins[i]];
                }
            }
            return array[input];
        }

        public List<int> ShortestCombination(int[] coins, int input)
        {
            var combos = new CoinChange();
            var result = combos.FindPossibleCombinationsDynamicProgramming(input, coins);
            var count = Int32.MaxValue;
            var shortest = 0;
            foreach (var VARIABLE in result)
            {
                if (VARIABLE.Count < count)
                {
                    shortest = result.IndexOf(VARIABLE);
                }
            }
            return result[shortest];
        }

        public List<List<int>> Combinations(int[] coins, int input)
        {
            var combos = new CoinChange();
            List<List<int>> listOfCombos = new List<List<int>>();
            var result = combos.FindPossibleCombinationsDynamicProgramming(input, coins);
            foreach (var list in result)
            {
                listOfCombos.Add(list);
            }
            return listOfCombos;
        }
    }
}

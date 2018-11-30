using System;
using System.Collections.Generic;
using System.Text;

namespace MinCoins
{
    public class Cell
    {
        public List<List<int>> Combinations { get; set; }

        public Cell()
        {
            Combinations = new List<List<int>>();
        }
        public void AddCombinations(List<int> combination)
        {
            if (!combination.Equals(null))
            {
                Combinations.Add(new List<int>(combination));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MinCoins
{
    [DataContract]
    public class InputInfoObject
    {
        [DataMember(Name = "Input")]
        public int Input { get; set; }
        [DataMember(Name = "Coins")]
        public int[] Coins { get; set; }
        [DataMember(Name = "ShortestComboOfCoins")]
        public List<int> ShortestComboOfCoins { get; set; }
        [DataMember(Name = "AmountOfCombosOfCoins")]
        public int AmountOfCombosOfCoins { get; set; }
        [DataMember(Name = "AllCombinations")]
        public List<List<int>> AllCombinations { get; set; }
        [DataMember(Name = "LengthOfShortestCombo")]
        public int LengthOfShortestCombo { get; set; }
        private readonly FindAmountAndWays _findShortestCombo = new FindAmountAndWays();
        public InputInfoObject(int input, int[] coins)
        {
            Input = input;
            Coins = coins;
        }

        public void Compute()
        {
            ShortestComboOfCoins = _findShortestCombo.ShortestCombination(Coins, Input);
            AllCombinations = _findShortestCombo.Combinations(Coins, Input);
            AmountOfCombosOfCoins = AllCombinations.Count;
            LengthOfShortestCombo = ShortestComboOfCoins.Count;
        }
    }
}

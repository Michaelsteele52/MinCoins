using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace MinCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] coins = {1,2,3};
            const int input = 10;
            var coinCombos = new InputInfoObject(input,coins);
            coinCombos.Compute();

            var stream1 = new MemoryStream();
            var output = new DataContractJsonSerializer(typeof(InputInfoObject));
            output.WriteObject(stream1,coinCombos);
            stream1.Position = 0;
            var reader = new StreamReader(stream1);
            Console.WriteLine(reader.ReadToEnd());
            Console.ReadKey();
            
        }
    }
}
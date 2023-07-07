using System;
using System.Collections.Generic;
namespace atm
{
    class Program
    {
        static void Main()
        {
            //Provide the inputs
            List<int> denominations = new List<int> { 10, 50, 100 }; // Available currency denominations
            int payoutAmount = 100; // The desired payout amount


            //Call the functions
            List<Dictionary<int, int>> combinations = GetDenominationCombinations(denominations, payoutAmount);
            PrintResult(payoutAmount, combinations);
            Console.Read();
        }
        static void PrintResult(int payoutAmount, List<Dictionary<int, int>> combinations)
        {
            Console.WriteLine($"Possible combinations for {payoutAmount}:");
            Console.WriteLine("*******************");
            foreach (Dictionary<int, int> combination in combinations)
            {
                foreach (var item in combination)
                {
                    if (item.Value > 0)
                    {
                        Console.WriteLine(string.Format("Denomination {0} * {1}", item.Key, item.Value));
                    }
                }
                Console.WriteLine("*******************");
            }
        }
        static List<Dictionary<int, int>> GetDenominationCombinations(List<int> denominations, int payoutAmount)
        {
            List<Dictionary<int, int>> result = new List<Dictionary<int, int>>();
            Dictionary<int, int> currentCombination = new Dictionary<int, int>();

            CalculateCombinations(denominations, payoutAmount, 0, currentCombination, result);

            return result;
        }

        static void CalculateCombinations(List<int> denominations, int amount, int index, Dictionary<int, int> currentCombination, List<Dictionary<int, int>> result)
        {
            if (amount == 0)
            {
                result.Add(new Dictionary<int, int>(currentCombination));
                return;
            }

            if (amount < 0 || index == denominations.Count)
                return;

            int denomination = denominations[index];
            int maxCount = amount / denomination;

            for (int count = maxCount; count >= 0; count--)
            {
                currentCombination[denomination] = count;
                int remainingAmount = amount - (count * denomination);
                CalculateCombinations(denominations, remainingAmount, index + 1, currentCombination, result);
                currentCombination.Remove(currentCombination.Count - 1);
            }
        }
    }
}

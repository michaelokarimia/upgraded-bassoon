using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseExercises
{
    class StockPriceProfitCalculator
    {
        internal static void Run()
        {
            // price of Apple stock yesterday in Dollars
            var stockPricesYesterday = new int[] { 10, 7, 5, 8, 11, 9};

            int profit = 0;

            profit = getMaxProfit(stockPricesYesterday);

            Console.WriteLine("Max profit is: {0}", profit);
        }

        //Given the stock prices yesterday, return the max profit that could have been made with one purchase and one sale of a share
        private static int getMaxProfit(int[] stockPricesYesterday)
        {
            var highest = 0;
            var lowest = int.MaxValue;

            for (int i = 0; i < stockPricesYesterday.Length; i++)
            {
                var current = stockPricesYesterday[i];
                if (current > highest)
                {
                    highest = current;
                }
                if (current < lowest)
                {
                    lowest = current;
                }
            }


            var profit = highest - lowest;

            return profit;
        }
    }
}

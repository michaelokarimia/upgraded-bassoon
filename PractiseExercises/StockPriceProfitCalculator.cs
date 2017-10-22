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
            // price of Apple stock yesterday in Dollars, in time order
            //each element represents a minute since market open time, value = price
            var stockPricesYesterday = new int[] { 100, 10, 7, 5, 8, 11, 9};

            int profit = 0;

            profit = getMaxProfit(stockPricesYesterday);

            Console.WriteLine("Max profit is: {0}", profit);
        }

        //Given the stock prices yesterday, return the max profit that could have been made with one purchase and one sale of a share
        //Order sensitive, can only compare prices with future increase.
        //assumes we do not return a negative number 9 i.e. a loss
        private static int getMaxProfit(int[] stockPricesYesterday)
        {
            if( stockPricesYesterday == null)
            {
                throw new Exception("Null Array passed in");
            }

            if (stockPricesYesterday.Length < 2)
            {
                throw new Exception("Invalid list of prices passed in, too few prices");
            }

            var maxProfit = 0;

            for (int i = 0; i < stockPricesYesterday.Length; i++)
            {
                var current = stockPricesYesterday[i];
                for (int n = i+1; n < stockPricesYesterday.Length; n ++)
                {
                    var nextPrice = stockPricesYesterday[n];

                    var potentialProfit = nextPrice - current;

                    if (potentialProfit > 0 && potentialProfit > maxProfit)
                    {
                        maxProfit = potentialProfit;
                    }

                }
            }



            return maxProfit;
        }
    }
}

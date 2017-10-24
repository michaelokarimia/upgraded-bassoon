using System;

namespace PractiseExercises
{
    internal class SumOfAllProductsExceptIndex
    {
        internal static void Run()
        {
            var input = new int[] {1,7,3,4};

            var output = GetProductsOfAllIntsExceptIndex(input);

            foreach(int i in output)
            {
                Console.WriteLine(i + ",");
            }
        }

        /// <summary>
        /// Greedy Approach O(n) complexity
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static int[] GetProductsOfAllIntsExceptIndex(int[] input)
        {
            if(input == null)
            {
                throw new Exception("Null array passed int");
            }

            if(input.Length < 2)
            {
                throw new Exception("Array too small");
            }

            var output = new int[input.Length];

            var runningTotal = 1;

            for(int i = 0; i < input.Length; i++)
            {
                output[i] = runningTotal;
                
                runningTotal *= input[i];
            }

            runningTotal = 1;

            for (int i = input.Length -1; i >=0; i--)
            {
                output[i] *= runningTotal;
                runningTotal *= input[i];
            }

            return output;
        }
    }
}
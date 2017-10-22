using System;

namespace PractiseExercises
{
    internal class SumOfAllProductsExceptIndex
    {
        internal static void Run()
        {
            var input = new int[] {  1,7,3,4};

            var output = GetProductsOfAllIntsExceptIndex(input);

            foreach(int i in output)
            {
                Console.WriteLine(i + ",");
            }
        }

        /// <summary>
        /// Nested loop, which means O(n^2) complexity
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

            for( int i = 0; i < input.Length; i++)
            {
                var current = 1;

                for (int n = 0; n < input.Length; n++)
                {
                    if (i != n)
                    {
                        current = current * input[n];
                    }
                            
                }

                output[i] = current;

            }

            return output;
        }
    }
}
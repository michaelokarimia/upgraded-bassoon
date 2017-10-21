using System;
using System.Collections.Generic;
using System.Text;

namespace PractiseExercises
{
    public class Fibonacci
    {
        internal static int Print(int n)
        {
            return runReducedMemoryVersion(n);
        }


        internal static int runWithArray(int n)
        {
            if (n < 2)
                return n;

            // O(n) space complexity, we need to store every previous number in sequence
            var list = new List<int>() { 0, 1 };

            //O(n) time complexity, we need to process every n items

            for (int i = 2; i < n; i++)
            {
                list.Add(list[i - 1] + list[i - 2]);
            }

            return list[n-1];
        }


        internal static int runReducedMemoryVersion(int n)
        {
            if (n < 2 )
                return n;
            
            int twoPrevious = 0;
            int previous = 1;
            int current = 0;
            
            for (int i = 2; i < n; i++)
            {
                current = twoPrevious + previous;
                twoPrevious = previous;
                previous = current;
            }
            
            return current;

        }
    }
}
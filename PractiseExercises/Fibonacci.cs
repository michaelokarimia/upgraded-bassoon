using System;
using System.Collections.Generic;
using System.Text;

namespace PractiseExercises
{
    public class Fibonacci
    {
        internal static int Print(int n)
        {
            return Run(n);
        }


        internal static int Run(int n)
        {
            if (n < 2)
                return n;

            var list = new List<int>() { 0, 1 };

            for (int i = 2; i < n; i++)
            {
                list.Add(list[i - 1] + list[i - 2]);
            }

            return list[n-1];
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiseExercises
{
    public class Fibonacci
    {

        public static void Run()
        {
            int n = 40;

            Console.WriteLine("The Fibbonacci Number {0} is {1}", n, Fibonacci.Print(n));
        }

        internal static int Print(int n)
        {
            return runRecursively(n);
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
            
            // O(n) time complexity, have to run through the loop of numbers in the sequence

            for (int i = 2; i < n; i++)
            {
                current = twoPrevious + previous;
                twoPrevious = previous;
                previous = current;
            }

            //only store the current and previous two variables rather than the whole array of previous numbers
            // O(1) space complexity!
            return current;

        }

        public static int runRecursively(int n)
        {
            if (n < 2)
                return n;

            /* for each execution, run yourself twice(!)
             * builds call stack as a binary tree, starting at fib(n), with n reducing at each level
             * when n = 0 you can start to add up values back from fib(n)
                                        fib(10) =
                            fib(9)          +               fib(8)
                   fib(8)    +     fib(7)            fib(7)   +       fib(6)
            fib(7)  + fib(6)  fib(6) + fib(5)   fib(6) + fib(5)  fib(5) + fib(4)
            
            O(2^n) time complexity and space complexity
            */
            return runRecursively(n - 1) + runRecursively(n - 2);


        }
    }
}
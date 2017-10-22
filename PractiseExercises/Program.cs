using System;

namespace PractiseExercises
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = 40;

            Console.WriteLine("The Fibbonacci Number {0} is {1}", n, Fibonacci.Print(n));

            Console.ReadKey();
        }
    }
}

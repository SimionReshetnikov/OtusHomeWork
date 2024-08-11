using System;
using System.Diagnostics;

namespace OtusHomeWork7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            FibonacсiNumberThroughRecursion(5);
            sw.Stop();
            Console.WriteLine($"Finding the 5th term of the fibonacci sequence using recursion: {sw.ElapsedTicks}");
            
            sw.Restart();
            FibonacсiNumberThroughRecursion(10);
            sw.Stop();
            Console.WriteLine($"Finding the 10th term of the fibonacci sequence using recursion: {sw.ElapsedTicks}");
            
            sw.Restart();
            FibonacсiNumberThroughRecursion(20);
            sw.Stop();
            Console.WriteLine($"Finding the 20th term of the fibonacci sequence using recursion: {sw.ElapsedTicks}");
            Console.WriteLine(new string('-', 50));

            sw.Restart();
            FibonacciNumberThroughWhile(5);
            sw.Stop();
            Console.WriteLine($"Finding the 5th term of the fibonacci sequence using while: {sw.ElapsedTicks}");

            sw.Restart();
            FibonacciNumberThroughWhile(10);
            sw.Stop();
            Console.WriteLine($"Finding the 10th term of the fibonacci sequence using while: {sw.ElapsedTicks}");

            sw.Restart();
            FibonacciNumberThroughWhile(20);
            sw.Stop();
            Console.WriteLine($"Finding the 20th term of the fibonacci sequence using while: {sw.ElapsedTicks}");
        }

        private static int FibonacсiNumberThroughRecursion(int number)
        {
            if(number == 0)
            {
                return 0;
            }
            else if (number == 1 || number == 2)
            {
                return 1;
            }
            else
            {
                return FibonacсiNumberThroughRecursion(number - 1) + FibonacсiNumberThroughRecursion(number - 2);
            }
        }

        private static int FibonacciNumberThroughWhile(int number)
        {
            int fibonacciNumber = 0;
            int numberOne = 0;
            int numberTwo = 1;
            if(number == 1 || number == 2)
            {
                return 1;
            }
            
            while(number >= 0)
            {
                fibonacciNumber += numberOne;
                numberOne = numberTwo;
                numberTwo = fibonacciNumber;
                number--;
            }
            return fibonacciNumber;
        }
    }
}

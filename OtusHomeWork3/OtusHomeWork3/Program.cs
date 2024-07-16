using System;
using System.Text;

namespace OtusHomeWork3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the program for solving quadratic equations.");
            var equation = new SolvingEquation();

            bool loopCondition;
            do
            {
                try
                {
                    Console.WriteLine("Enter a value A:");
                    equation.PrintParameterA(Console.ReadLine());
                    Console.WriteLine(equation);

                    Console.WriteLine("Enter a value B:");
                    equation.PrintParameterB(Console.ReadLine());
                    Console.WriteLine(equation);

                    Console.WriteLine("Enter a value C:");
                    equation.PrintParameterC(Console.ReadLine());
                    Console.WriteLine(equation);
                    loopCondition = false;

                    Console.WriteLine(equation.CalculationOfSolutionToTheEquation());
                }
                catch (NegativeDiscriminantException ex)
                {
                    FormatData(ex.Message, Severity.Warning, equation.EquationValuesInString);
                    loopCondition = false;
                }
                catch (OverflowException)
                {
                    string message = $"You can enter values from {Int32.MinValue}" +
                        $" to {Int32.MaxValue}";
                    FormatData(message, Severity.Overflow, equation.EquationValuesInString);
                    loopCondition = true;
                }
                catch (Exception ex)
                {
                    FormatData("No real values found.", Severity.Error, equation.EquationValuesInString);
                    loopCondition = true;
                }
            }
            while (loopCondition);
        }

        private static void FormatData(string message, Severity severity, 
            IDictionary<int, string> EquationsValues)
        { 
            if(severity == Severity.Error)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string('-', 50));
                Console.WriteLine(message);
                Console.WriteLine(new string('-', 50));
                PrintDictionary(EquationsValues);
                Console.ResetColor();
            }
            else if(severity == Severity.Warning)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string('-', 50));
                Console.WriteLine(message);
                Console.WriteLine(new string('-', 50));
                Console.ResetColor();
            }
            else if(severity == Severity.Overflow)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(new string('-', 50));
                Console.WriteLine(message);
                Console.WriteLine(new string('-', 50));
                PrintDictionary(EquationsValues);
                Console.ResetColor();
            }
        }

        private static void PrintDictionary(IDictionary<int, string> dictionary)
        {
            for (int i = 0; i < dictionary.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.WriteLine($"a = {dictionary[i]}");
                        break;
                    case 1:
                        Console.WriteLine($"b = {dictionary[i]}");
                        break;
                    default:
                        Console.WriteLine($"c = {dictionary[2]}");
                        break;
                }
            }
           
        }
    }

    public enum Severity
    {
        Warning, Error, Overflow
    }
}

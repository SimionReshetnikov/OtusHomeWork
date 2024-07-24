using System;
using System.Text.RegularExpressions;

namespace OtusHomeWork05
{
    public class Program
{
    private static void Main(string[] args)
    {
        var quadcopter = new Quadcopter();
        var regex = new Regex("[1-3]{1}");

        Console.WriteLine(quadcopter.GetInfo());
        while(true)
        {
            try
            {
                Console.WriteLine("Enter a command from the list.");
                string? command = Console.ReadLine();

                if (command == null)
                {
                    Console.WriteLine("The input line is empty.");
                }
                else if (regex.IsMatch(command))
                {
                    switch (command)
                    {
                        case "1":

                            foreach (var elements in quadcopter.GetComponents())
                            {
                                Console.WriteLine(elements);
                            }
                            break;

                        case "2":

                            quadcopter.Charge();
                            break;

                        case "3":

                            Console.WriteLine(quadcopter.GetRobotType());
                            break;
                    }
                }
                else
                {
                    throw new FormatException();
                }

                Console.WriteLine("\nPress Escape to exit the program " +
                    "or press any key to continue.");

                ConsoleKey key = Console.ReadKey().Key;

                if(key == ConsoleKey.Escape)
                {
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format.");
            }
        }
    }
}
}

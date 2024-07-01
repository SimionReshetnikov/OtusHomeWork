using System;

namespace OtusHomeWork1
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Greating();
            Commands commandsProgram = new Commands(); 

            while(commandsProgram.Flag)
            {
                string? commands = Console.ReadLine();
                switch (commands)
                {
                    case "/start":

                        commandsProgram.Start();
                        break;

                    case "/help":

                        commandsProgram.Help();
                        break;

                    case "/info":

                        commandsProgram.Info();
                        break;

                    case "/echo":

                        if (commandsProgram.Name == null)
                        {
                            Console.WriteLine("The /start command has not " +
                                "been called. Enter a command from the list.");
                            break;
                        }
                        Console.WriteLine($"{commandsProgram.Name}, type something up.");
                        commandsProgram.Echo(Console.ReadLine());
                        break;

                    case "/exit":

                        commandsProgram.Exit();
                        break;

                    default:

                        if(commandsProgram.Name != null)
                        {
                            Console.WriteLine($"{commandsProgram.Name}, enter" +
                                $" the command from the list");
                        }
                        Console.WriteLine("Enter a command from the list.");
                        break;
                }
            }
        }

        private static void Greating()
        {
            Console.WriteLine("Welcome to the programme. Here is a list" +
                " of available commands: ");
            Console.WriteLine("/start");
            Console.WriteLine("/help");
            Console.WriteLine("/info");
            Console.WriteLine("/exit");
        }
    }
}

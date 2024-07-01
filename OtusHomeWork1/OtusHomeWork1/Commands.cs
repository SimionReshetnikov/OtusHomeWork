using System;


namespace OtusHomeWork1
{
    public class Commands
    {
        public string? Name { get; set; }
        public DateOnly Date { get; } = new DateOnly(2024, 6, 20);
        public bool Flag { get; set; } = true;

        public void Start()
        {
            Console.WriteLine("Please, enter your name");
            Name = Console.ReadLine();
            Console.WriteLine($"{Name}, enter the command from the list." +
                $" You now have access to the /echo command.");
        }

        public void Help()
        {
            if (Name != null)
            {
                Console.WriteLine($"{Name} this is what the " +
                    $"programme can do: ");
            }

            Console.WriteLine("/start - the programme saves " +
                "the user name and allows access to the command /echo.");

            Console.WriteLine("/help - shows what the programme can do.");

            Console.WriteLine("/info - provides information about the " +
                "software version and the date of its creation.");

            Console.WriteLine("/echo - displays the entered " +
                "text on the screen.");

            Console.WriteLine("/exit - ends the execution of the programme.");

            if (Name != null)
            {
                Console.WriteLine($"{Name}, enter" +
                                $" the command from the list");
            }
            else
            {
                Console.WriteLine("Enter a command from the list");
            }
        }

        public void Info()
        {
            if (Name != null)
            {
                Console.WriteLine($"{Name}, here is information about the" +
                    $" programme");
            }

            Console.WriteLine("Programme version: 1.0.0");
            Console.WriteLine($"Date of creation of the programme: {Date}");

            if (Name != null)
            {
                Console.WriteLine($"{Name}, enter" +
                                $" the command from the list.");
            }
            else
            {
                Console.WriteLine("Enter a command from the list.");
            }
        }

        public void Echo(string? message)
        {
            Console.WriteLine(message);
            Console.WriteLine($"{Name}, enter" +
                                $" the command from the list.");
        }

        public bool Exit()
        {
            if (Name != null)
            {
                Console.WriteLine($"Bye, {Name}");
            }
            else
            {
                Console.WriteLine("Bye.");
            }
            Flag = false;
            return Flag;
        }
    }
}

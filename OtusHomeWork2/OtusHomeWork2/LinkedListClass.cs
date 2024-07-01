using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace OtusHomeWork2
{
    public class LinkedListClass : IFormatTimes, ICollections
    {
        public Stopwatch stopwatch { get; set; } = new Stopwatch();

        public Random random { get; } = new Random();

        public TimeSpan tWorks { get; set; }
        public LinkedList<int> linkedList { get; init; }

        public LinkedListClass()
        {
            linkedList = new LinkedList<int>();
        }

        public void AddValuesInCollection()
        {
            Console.WriteLine("Filling the collection with random values.");

            stopwatch.Start();

            for (int i = 0; i < 1_000_000; i++)
            {
                linkedList.AddLast(random.Next(0, Int32.MaxValue));
            }

            stopwatch.Stop();

            tWorks = stopwatch.Elapsed;
            Console.WriteLine($"The collection is complete, time to complete the operation: + {IFormatTimes.FormatTime(tWorks)}");
        }

        public void FindingAnItemInACollection()
        {
            Console.WriteLine("I'm starting a search for 496753 items in the collection.");

            stopwatch.Start();

            int index = linkedList.ElementAt(496753);

            stopwatch.Stop();

            tWorks = stopwatch.Elapsed;
            Console.WriteLine($"Item index 496753: {index}");
            Console.WriteLine($"Operation completed, execution time: {IFormatTimes.FormatTime(tWorks)}");
        }

        public void DivisionElementsInto777()
        {
            Console.WriteLine("I start the operation of dividing the elements " +
                "of the collection by 777 without remainder.");

            stopwatch.Start();

            foreach (int i in linkedList)
            {
                if (i % 777 == 0)
                {
                    Console.WriteLine(i);
                }
            }

            stopwatch.Stop();

            tWorks = stopwatch.Elapsed;
            Console.WriteLine($"Operation completed, execution time: {IFormatTimes.FormatTime(tWorks)}");
        }
    }
}

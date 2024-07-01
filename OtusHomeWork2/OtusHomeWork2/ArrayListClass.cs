using System;
using System.Collections;
using System.Diagnostics;


namespace OtusHomeWork2
{
    public class ArrayListClass : IFormatTimes, ICollections
    {
        public Stopwatch stopwatch { get; set; } 

        public Random random { get; } = new Random();

        public TimeSpan tWorks { get; set; }
        public ArrayList arrayList { get; init; }

        public ArrayListClass() 
        {
            stopwatch = new Stopwatch();
            arrayList = new ArrayList();
        }

        public void AddValuesInCollection()
        {
            Console.WriteLine("Filling the collection with random values.");

            stopwatch.Start();

            for(int i = 0; i < 1_000_000; i++)
            {
                arrayList.Add(random.Next(0, Int32.MaxValue));
            }

            stopwatch.Stop();
            
            tWorks = stopwatch.Elapsed;
            Console.WriteLine($"The collection is complete, time to complete the operation: + {IFormatTimes.FormatTime(tWorks)}");
        }

        public void FindingAnItemInACollection()
        {
            Console.WriteLine("I'm starting a search for 496753 items in the collection.");

            stopwatch.Start();

            int value = 0;
            int index = 0;
            stopwatch.Start();

            foreach (int i in arrayList)
            {
                if (index == 496753)
                {
                    value = i;
                    break;
                }
                index++;
            }

            stopwatch.Stop();

            tWorks = stopwatch.Elapsed;
            Console.WriteLine($"Item index 496753: {value}");
            Console.WriteLine($"Operation completed, execution time: {IFormatTimes.FormatTime(tWorks)}");
        }

        public void DivisionElementsInto777()
        {
            Console.WriteLine("I start the operation of dividing the elements " +
                "of the collection by 777 without remainder.");

            stopwatch.Start();

            foreach (int i in arrayList)
            {
                if(i % 777 == 0)
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

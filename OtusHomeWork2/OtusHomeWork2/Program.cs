using System;
using System.Threading;

namespace OtusHomeWork2
{
    public class Program
    {
        private static void Main(string[] args)
        {
            ICollections array = new ArrayListClass();
            array.AddValuesInCollection();
            array.FindingAnItemInACollection();
            array.DivisionElementsInto777();

            Console.WriteLine();
            Thread.Sleep(2000);

            ICollections linkedListClass = new LinkedListClass();
            linkedListClass.AddValuesInCollection();
            linkedListClass.FindingAnItemInACollection();
            linkedListClass.DivisionElementsInto777();

            Console.WriteLine();
            Thread.Sleep(2000);

            ICollections listClass = new ListClass();
            listClass.AddValuesInCollection();
            listClass.FindingAnItemInACollection();
            listClass.DivisionElementsInto777();
        }
    }
}

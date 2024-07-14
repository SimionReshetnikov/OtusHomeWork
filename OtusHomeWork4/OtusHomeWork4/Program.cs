
namespace OtusHomeWork4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Main task");
            var stack = new Stack("one", "two", "three", "four", "five");

            stack.PrintStack(x => Console.WriteLine(x));

            Console.WriteLine($"Size = {stack.Size}, Top = {stack.Top}");

            var deleted = stack.Pop();
            stack.PrintStack(x => Console.WriteLine(x));
            Console.WriteLine($"Removing the top element {deleted}, Size = {stack.Size}, Top = {stack.Top}");

            stack.Add("six");
            stack.PrintStack(x => Console.WriteLine(x));
            Console.WriteLine($"Size = {stack.Size}, Top = {stack.Top}");

            try
            {
                while (stack.Size > 0)
                {
                    Console.WriteLine(stack.Pop());
                }
                Console.WriteLine(stack.Pop());
            }
            catch (StackIsEmptyException ex)
            {
                Console.WriteLine($"Exception StackEmptyException: {ex.Message}");
            }

            Console.WriteLine($"Size = {stack.Size}, " +
                $"Top = {(stack.Top == null ? "null" : stack.Top)}");

            Console.WriteLine("Additional task 1");
            var s1 = new Stack("a", "b", "c");
            var s2 = new Stack("1", "2", "3");
            s1.Merge(s2);
            s1.PrintStack(x => Console.WriteLine(x));

            Console.WriteLine("Additional task 2");
            var concatStack = Stack.Concat(new Stack("1", "2", "3"),
                new Stack("4", "5", "6"),
                new Stack("7", "8", "9"));
            concatStack.PrintStack(x => Console.WriteLine(x));

        }

    }
}

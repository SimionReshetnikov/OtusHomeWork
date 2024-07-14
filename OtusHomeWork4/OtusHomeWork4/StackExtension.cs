using System;

namespace OtusHomeWork4
{
    internal static class StackExtension
    {
        public static void Merge(this Stack s1, Stack s2)
        {
            string[] elements = new string[s2.Size];
            for (int j = 0; j <= s2.Size + 1; j++)
            {
                elements[j] = s2.Pop();
            }

            for (int i = 0; i < elements.Length; i++)
            {
                s1.Add(elements[i]);
            }
        }
    }
}

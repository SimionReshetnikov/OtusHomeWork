using System;

namespace OtusHomeWork4
{
    internal static class StackExtension
    {
        public static void Merge(this Stack s1, Stack s2)
        {
            string[] elements = s2.RetrieveElements(s2.Reverse(s2));

            for (int i = 0; i < elements.Length; i++)
            {
                s1.Add(elements[i]);
            }
        }
    }
}

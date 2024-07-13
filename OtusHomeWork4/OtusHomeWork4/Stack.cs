﻿
namespace OtusHomeWork4
{
    internal class Stack
    {
        private class NestedStackItem //вложенный класс, хранящий элемент и ссылку на следующий элемент
        {
            public string Element { get; set; }
            public NestedStackItem? NextStackItem { get; set; }
        }
        private NestedStackItem FirstElement { get; set; }
        public int Size
        {
            get
            {
                NestedStackItem current = FirstElement;
                int counter = 0;
                while (current != null)
                {
                    current = current.NextStackItem;
                    counter++;
                }
                return counter;
            }
        }
        public string? Top { get; set; }
        public Stack(params string[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                Add(elements[i]);
            }
        }

        public void Add(string element)
        {
            if (FirstElement == null)
            {
                FirstElement = new NestedStackItem() { Element = element };
            }
            else
            {
                NestedStackItem current = FirstElement;
                while (current.NextStackItem != null)
                {
                    current = current.NextStackItem;
                }
                current.NextStackItem = new NestedStackItem() { Element = element };
            }
            Top = element;
        }

        public void PrintStack(Action<string> action)
        {
            NestedStackItem current = FirstElement;

            while (current != null)
            {
                action(current.Element);
                current = current.NextStackItem;
            }
        }

        public string? Pop()
        {
            var current = FirstElement;
            NestedStackItem? previousElement = null;

            try
            {
                if(current == null)
                {
                    throw new StackIsEmptyException("The stack is empty.");
                }
                var nameElement = current.Element;

                if(current.NextStackItem == null)
                {
                    Top = "null";
                    FirstElement = null;
                    return nameElement;
                }
                while (current.NextStackItem != null)
                {
                    nameElement = current.NextStackItem.Element;
                    previousElement = current;
                    current = current.NextStackItem;
                }

                if (previousElement != null)
                {
                    previousElement.NextStackItem = null;
                    Top = previousElement.Element;
                }
                

                return nameElement;
            }
            catch (StackIsEmptyException ex)
            {
                return ex.Message;
            }
        }

        public Stack Reverse(Stack stack) 
        {
            
            var reversedStack = new Stack(); // новый стек с элементами принимаемого стека в обратном порядке
            var current = stack.FirstElement; //счетчик для перебора текущего стека
            NestedStackItem? previousNestedStackItem = null; //ссылка на предыдущий элемент
            NestedStackItem? reversedStackItem = null; //текущий элемент
            string? topElement = null; // значение верхнего элемента

            while(current != null)
            {
                reversedStackItem = new NestedStackItem();
                reversedStackItem.Element = current.Element;
                reversedStackItem.NextStackItem = previousNestedStackItem;

                topElement ??= current.Element; 

                previousNestedStackItem = reversedStackItem;
                current = current.NextStackItem;
            }

            if (reversedStackItem != null)
            {
                reversedStack.FirstElement = reversedStackItem;
            }
            
            Top = topElement;
            return reversedStack;
        }

        public string[] RetrieveElements(Stack stack) 
        {
            var current = stack.FirstElement;
            string[] elements = new string[stack.Size];
            int counter = 0;
            while(current != null)
            {
                elements[counter] ??= current.Element;
                current = current.NextStackItem;
                counter++;
            }
            return elements;
        }
        public static Stack Concat(params Stack[] stack)
        {
            var concatStack = new Stack();
            foreach (var item in stack)
            {
                item.Reverse(item);
                string[] elements = item.RetrieveElements(item.Reverse(item));

                for(int i = 0; i < elements.Length; i++)
                {
                    concatStack.Add(elements[i]);
                }
            }
            return concatStack;
        }
    }
}
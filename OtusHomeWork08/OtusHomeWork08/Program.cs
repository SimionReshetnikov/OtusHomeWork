using System;

namespace OtusHomeWork08
{
    public delegate void TreeMethodDel<T>(T tree);

    internal class Program
    {
        static void Main(string[] args)
        {
            TreeMethodDel<Tree> treeMethodDel = AddNameAndSalary;
            treeMethodDel += PrintTreeElement;
            treeMethodDel += GetNameElement;

            while(true)
            {
                Tree tree = new Tree();

                treeMethodDel(tree);

                while(true)
                {
                    Console.WriteLine("Введите 0, чтобы перейти к началу программы или 1," +
                                       " чтобы ввести интересующий размер зарплаты.");

                    var consoleKey = Console.ReadLine();

                    if (consoleKey == "0")
                    {
                        break;
                    }
                    else if (consoleKey == "1")
                    {
                        GetNameElement(tree);
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Вы должны ввести 0 или 1.");
                    }
                }
            }
        }

        private static void AddNameAndSalary(Tree tree)
        {
            while (true)
            {
                Console.WriteLine("Введите имя сотрудника.");
                string nameEmployee = Console.ReadLine();

                if (nameEmployee == "")
                {
                    Console.WriteLine("Ввод окончен.");
                    break;
                }

                Console.WriteLine("Введите заработную плату сотрудника.");
                int salaryEmployee;
                try
                {
                    salaryEmployee = Convert.ToInt32(Console.ReadLine());

                    if (salaryEmployee <= 0)
                    {
                        Console.WriteLine("Неприемлимое значение.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Неприемлимое значение.");
                    continue;
                }
                Employee emp = new Employee(nameEmployee);
                emp.Salary = salaryEmployee;

                NodeBinaryTree node = new NodeBinaryTree();
                node.PersonEmp = emp;
                tree.Add(node);
            }
        }

        private static void PrintTreeElement(Tree tree)
        {
            tree.Inorder(tree.Root);

            foreach (var item in tree.EmployeesInformation)
            {
                Console.WriteLine($"{item} ");
            }
        }

        public static void GetNameElement(Tree tree)
        {
            Console.WriteLine("Введите интересующий размер зарплаты.");

            int readSalary;
            while (true)
            {
                try
                {
                    readSalary = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Неприемлимое значение.");
                    continue;
                }

                break;
            }

            Console.WriteLine(tree.ShowName(readSalary));
        }
    }
}

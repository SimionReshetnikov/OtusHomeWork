using System;
using System.Collections.Generic;

namespace OtusHomeWork08
{
    internal class Tree
    {
        public NodeBinaryTree? Root { get; set; }
        public List<string> EmployeesInformation { get; set; } = new List<string>();

        public Tree(NodeBinaryTree? root)
        {
            Root = root;
        }

        public Tree()
        {
            Root = null;
        }

        public void Add(NodeBinaryTree element)
        {
            if(Root == null)
            {
                Root = element;
                return;
            }

            NodeBinaryTree node = Root;
            while (true)
            {
                if (element.PersonEmp.Salary < node.PersonEmp.Salary)
                {
                    if(node.LeftChild != null)
                    {
                        node = node.LeftChild;
                        continue;
                    }
                    else
                    {
                        node.LeftChild = element;
                        return;
                    }
                }
                else
                {
                    if (node.RightChild != null)
                    {
                        node = node.RightChild;
                        continue;
                    }
                    else
                    {
                        node.RightChild = element;
                        return;
                    }
                }
            }
        }

        public void Inorder(NodeBinaryTree root)
        {
            if(root != null)
            {
                Inorder(root.LeftChild);

                EmployeesInformation.Add($"{root.PersonEmp.Name} - {root.PersonEmp.Salary}");

                Inorder(root.RightChild);
            }
        }

        public string ShowName(int salary)
        {
            NodeBinaryTree root = Root;

            while(true)
            {
                if(root == null)
                {
                    return "Такой сотрудник не найден";
                }
                if(root.PersonEmp.Salary > salary)
                {
                    root = root.LeftChild;
                    continue;
                }
                else if(root.PersonEmp.Salary < salary)
                {
                    root = root.RightChild;
                    continue;
                }
                else
                {
                    return root.PersonEmp.Name;
                }
            }
        }
    }
}

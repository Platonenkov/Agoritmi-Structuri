using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree();
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(10);
            tree.Insert(30);
            tree.Insert(80);
            tree.Insert(29);
            tree.Insert(31);
            tree.Insert(32);
            tree.Insert(70);
            BinaryTree.Print(tree);
        }

    }
    class BinaryTree
    {
        public long? Data { get; private set; }
        public BinaryTree Left { get; set; }
        public BinaryTree Right { get; set; }
        public BinaryTree Parent { get; set; }

        /// <summary>
        /// Добавляет число в дерево
        /// </summary>
        /// <param name="data">число</param>
        public void Insert(long data)
        {
            if (Data == null || Data == data)
            {
                Data = data;
                return;
            }
            if (Data > data)
            {
                if (Left == null) Left = new BinaryTree();
                Insert(data, Left, this);
            }
            else
            {
                if (Right == null) Right = new BinaryTree();
                Insert(data, Right, this);
            }
        }

        /// <summary>
        /// добавляет число в дерево
        /// </summary>
        /// <param name="data">число</param>
        /// <param name="node">ветьв дерева куда вставляем</param>
        /// <param name="parent">родитель ветви</param>
        private void Insert(long data, BinaryTree node, BinaryTree parent)
        {

            if (node.Data == null || node.Data == data)
            {
                node.Data = data;
                node.Parent = parent;
                return;
            }
            if (node.Data > data)
            {
                if (node.Left == null) node.Left = new BinaryTree();
                Insert(data, node.Left, node);
            }
            else
            {
                if (node.Right == null) node.Right = new BinaryTree();
                Insert(data, node.Right, node);
            }
        }
        /// <summary>
        /// Печать данных дерева
        /// </summary>
        /// <param name="node">дерево</param>
        public static void Print(BinaryTree node)
        {
            if (node != null)
            {
                if (node.Parent == null)
                {
                    Console.WriteLine("Корень: {0}", node.Data);
                }
                else
                {
                    if (node.Parent.Left == node)
                    {
                        Console.WriteLine("левый для {1}  --> {0}", node.Data, node.Parent.Data);
                    }

                    if (node.Parent.Right == node)
                    {
                        Console.WriteLine("правый для {1} --> {0}", node.Data, node.Parent.Data);
                    }
                }
                if (node.Left != null)
                {
                    Print(node.Left);
                }
                if (node.Right != null)
                {
                    Print(node.Right);
                }
            }
        }

        /// <summary>
        /// Ищет число в дереве
        /// </summary>
        /// <param name="data">число</param>
        private bool BinaryFinde(long data, BinaryTree node)
        {

            if (node.Data == data)
            {

                return true;
            }
            if (node.Data > data)
            {
                if (node.Left == null) node.Left = new BinaryTree();
                Insert(data, node.Left, node);
            }
            else
            {
                if (node.Right == null) node.Right = new BinaryTree();
                Insert(data, node.Right, node);
            }
            return false;
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace PractiseExercises
{
    internal class TreeChecker
    {
        public class Node
        {
            public List<Node> Children { get; set; } = new List<Node>(); 
        }

        internal static void Run()
        {
            var rootNode = new Node();

            //rootNode.Children = new List<Node>() { new Node { }, new Node() { Children = new List<Node>() { new Node(), new Node(), new Node() } } };
            rootNode.Children = new List<Node>() { new Node { }, new Node() { Children = new List<Node>() { new Node(), new Node() } } };


            bool isTree = GetIfItIsATree(rootNode);

            Console.WriteLine("It is{0}a binary tree", (isTree) ? " " : " not ");

            BinaryTree binaryTree = new BinaryTree("home");



            bool isBalanced = (isTree) ? GetIfTreeIsBalanced(binaryTree) : false;

            Console.WriteLine("It is{0}a balanced binary tree", (isBalanced) ? " " : " not ");



        }

        /// <summary>
        /// Balanced means that the height between the shallowest and deepest nodes will not exceed 1
        /// </summary>
        /// <param name="rootNode"></param>
        /// <returns></returns>
        private static bool GetIfTreeIsBalanced(BinaryTree rootNode)
        {
            bool isBalanced = false;

            //traverse all nodes in this binary tree

           
            return isBalanced;
        }

        //depth first search implmentation
        private static bool GetIfItIsATree(Node rootNode)
        {
            if (rootNode == null)
                return false;

            //traverse all children nodes in root node
            //tree has only 0,1 or 2 child nodes it's binary

            var stack = new Stack<Node>();

            stack.Push(rootNode);
            //traverse all nodes and push them onto a stack

            while (stack.Count > 0)
            {
                if (stack.Peek() == null)
                {
                    break;
                }

                var currentNode = stack.Pop();

                //non binary tree to exit now
                if (currentNode.Children.Count > 2)
                    return false;

                //if there are any children. push them onto to stack for evaluation
                foreach (Node node in currentNode.Children)
                {
                    stack.Push(node);
                }

            }

            return true;

        }

        private class BinaryTree
        {
            public object Value { get; private set; }
            public BinaryTree Right { get; private set; }
            public BinaryTree Left { get; private set; }

            public BinaryTree(object val)
            {
                Value = val;
            }

            public BinaryTree AddRight(object val)
            {
                Right = new BinaryTree(val);
                return Right;
            }

            public BinaryTree AddLeft(object val)
            {
                Left = new BinaryTree(val);
                return Left;
            }

        }
    }
}
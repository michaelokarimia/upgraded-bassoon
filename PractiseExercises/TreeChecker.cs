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

            rootNode.Children = new List<Node>()
                { new Node
                    { Children =
                        {
                         new Node {
                            Children = new List<Node>() {
                                new Node(),
                                }
                            },
                         
                            new Node {
                                Children = new List<Node>() {
                                    new Node(),
                                    new Node()
                                    }
                                }
                                
                            }
                        }
                };
            //rootNode.Children = new List<Node>() { new Node { }, new Node() { Children = new List<Node>() { new Node(), new Node(), new Node() } } };
            //rootNode.Children = new List<Node>() { new Node { }, new Node() { Children = new List<Node>() { new Node(), new Node() } } };
            //rootNode.Children = new List<Node>();
            //rootNode.Children = new List<Node>() { new Node { Children = { new Node(), new Node { Children = { new Node(), new Node() } } } }, new Node()   }  ;
            //rootNode.Children = new List<Node>() { new Node { }, new Node() { Children = new List<Node>() { new Node(), new Node() { Children = { new Node() } } } } };

            bool isTree = GetIfItIsATree(rootNode);

            Console.WriteLine("It is{0}a binary tree", (isTree) ? " " : " not ");



            bool isBalanced = (isTree) ? GetIfTreeIsBalanced(rootNode) : false;

            Console.WriteLine("It is{0}a balanced binary tree", (isBalanced) ? " " : " not ");



        }

        /// <summary>
        /// Balanced means that the height between the shallowest and deepest nodes will not exceed 1
        /// </summary>
        /// <param name="rootNode"></param>
        /// <returns></returns>
        private static bool GetIfTreeIsBalanced(Node rootNode)
        {
            //traverse all nodes in this binary tree depth first

            var stack = new Stack<Node>();

            stack.Push(rootNode);

            var currentDepth = 0;

            var shallowestLeaf = int.MaxValue;
            var deepestLeaf = 0;


            while(stack.Count > 0)
            {
                var current = stack.Pop();

                //leaf node
                if(current.Children.Count == 0)
                {
                    currentDepth++;
                    if(currentDepth < shallowestLeaf)
                    {
                        shallowestLeaf = currentDepth;
                    }

                    if (currentDepth > deepestLeaf)
                    {
                        deepestLeaf = currentDepth;
                    }
                }

                foreach(Node node in current.Children)
                {
                    stack.Push(node);
                }

            }


            if (deepestLeaf - shallowestLeaf > 2)
            {
                return false;
            }
            else
            { return true; }

           
        }

        //breath first search implmentation
        private static bool GetIfItIsATree(Node rootNode)
        {
            if (rootNode == null)
                return false;

            //traverse all children nodes in root node
            //tree has only 0,1 or 2 child nodes it's binary

            Queue<Node> q = new Queue<Node>();

            q.Enqueue(rootNode);

            while (q.Count > 0)
            {
                var current = q.Dequeue();

                if (current.Children.Count > 2)
                { return false; }

                foreach(Node node in current.Children)
                {
                    q.Enqueue(node);   
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
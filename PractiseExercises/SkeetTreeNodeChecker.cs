using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseExercises
{
    class SkeetTreeNodeChecker
    {

        public class Node
        {
            public List<Node> Children { get; set; } = new List<Node>();
        }


        internal static void RunNodeChecker()
        {
            var rootNode = new Node();

            var unabalancedLLLRNode = new Node()
            {
                Children =
                    { new Node
                        {
                        Children =
                            {
                                 new Node
                                 {
                                    Children =
                                    {
                                        new Node(),
                                    }
                                 },
                                new Node
                                {
                                    Children =
                                    {
                                        new Node(),
                                    }
                                }

                            }
                        }
                }
            };

            var unbalancedNode = new Node
            {
                Children =
                {
                    new Node
                    {
                        Children =
                        {
                            new Node
                            {
                                Children =
                                {
                                    new Node(),
                                }
                            },

                            new Node
                            {
                                Children =
                                {
                                    new Node(),
                                }

                            }
                        }
                    }
                }
            };

            var balancedNode = new Node
            {
                Children =
                {
                    new Node
                    {
                    Children =
                        {
                             new Node
                             {
                                Children =
                                 {
                                    new Node(),
                                 }
                             },

                            new Node {
                                Children =
                                {
                                    new Node(),
                                }
                            }
                        }
                    },
                    new Node
                    {
                        Children =
                        {

                            new Node
                            {
                                Children =
                                {
                                    new Node(),
                                }
                            },

                            new Node
                            {
                                Children =
                                {
                                    new Node(),
                                }
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

            rootNode = balancedNode;

            bool isTree = GetIfItIsATree(rootNode);

            Console.WriteLine("It is{0}a binary tree", (isTree) ? " " : " not ");



            bool isBalanced = (isTree) ? GetIfTreeIsBalanced(rootNode) : false;

            Console.WriteLine("It is{0}a balanced binary tree", (isBalanced) ? " " : " not ");



        }

        /// <summary>
        /// Balanced means that the height between the Left s and deepest nodes which are not full will not exceed 1
        /// </summary>
        /// <param name="rootNode"></param>
        /// <returns></returns>
        private static bool GetIfTreeIsBalanced(Node rootNode)
        {
            //traverse all nodes in this binary tree depth first

            var stack = new Stack<Node>();

            stack.Push(rootNode);

            var currentDepth = 0;

            var shallowestNotFullNode = int.MaxValue;
            var deepestNotFullNode = 0;


            while (stack.Count > 0)
            {
                var current = stack.Pop();
                currentDepth++;
                //node which doesn't have two children is not full
                if (current.Children.Count < 2)
                {

                    if (currentDepth < shallowestNotFullNode)
                    {
                        shallowestNotFullNode = currentDepth;
                    }

                    if (currentDepth > deepestNotFullNode)
                    {
                        deepestNotFullNode = currentDepth;
                    }
                }

                foreach (Node node in current.Children)
                {
                    stack.Push(node);
                }

            }


            if (deepestNotFullNode - shallowestNotFullNode > 1)
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

                foreach (Node node in current.Children)
                {
                    q.Enqueue(node);
                }
            }

            return true;

        }
    }
}

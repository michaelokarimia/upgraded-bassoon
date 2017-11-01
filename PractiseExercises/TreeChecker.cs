using System;

namespace PractiseExercises
{
    internal class TreeChecker
    {
         




        public static void Run()
        {

            ///* Given a binary tree, check if it is balanced
            ///Balanced is taken to be a tree such that the heights of the two subtrees of any node
            ///never differ by more that one
            ///

            BinaryTree tree = new BinaryTree('#');
            
            bool IsBalanced = false;

            tree = BuildUnbalancedTree();

            IsBalanced = getIfTreeBalanced(tree);

            Console.WriteLine("Tree is{0}balanced", (IsBalanced) ? " " : " not ");

        }

        private static BinaryTree BuildTreeWithHeightDiffOfOne()
        {
            var root = new BinaryTree(1);

            var treeLeft = root.AddLeft(3);
            var treeRight = root.AddRight(4);

            var leftleft = treeLeft.AddLeft(6);
            var leftRight = treeLeft.AddRight(9);

            treeRight.AddLeft(11);
            var rightright = treeRight.AddRight(19);
            var rightrightright = rightright.AddRight(21);


            var leftleftleft = leftleft.AddLeft(17);


            leftleftleft.AddLeft(5);

            return root;
        }

        private static BinaryTree BuildTreeWithHeightDiffOfTwo()
        {
            var root = new BinaryTree(1);

            var treeLeft = root.AddLeft(3);
            var treeRight = root.AddRight(4);

            var leftleft = treeLeft.AddLeft(6);
            var leftRight = treeLeft.AddRight(9);

            treeRight.AddLeft(11);
            treeRight.AddRight(19);

            var leftleftleft = leftleft.AddLeft(17);

            leftleftleft.AddLeft(5);

            return root;
        }

        private static BinaryTree BuildBalancedTree()
        {

            var balancedTreeHeight2 = new BinaryTree(1);

            var blancedTreeleft = balancedTreeHeight2.AddLeft(3);
            var balancedTreeRight = balancedTreeHeight2.AddRight(4);

            blancedTreeleft.AddLeft(6);
            blancedTreeleft.AddRight(9);

            balancedTreeRight.AddLeft(11);
            balancedTreeRight.AddRight(19);

            return balancedTreeHeight2;
        }

        private static BinaryTree BuildUnbalancedTree()
        {
            var  unbalanced = new BinaryTree(1);

            var unblancedTreeleft = unbalanced.AddLeft(3);

            var leftleft = unblancedTreeleft.AddLeft(6);
            unblancedTreeleft.AddRight(9);

            leftleft.AddLeft(11);
            leftleft.AddRight(19);

            return unbalanced;
        }

        private static bool getIfTreeBalanced(BinaryTree tree)
        {
            if (tree == null)
                return false;

            return getHeight(tree) != int.MinValue;

        }

        private static int getHeight(BinaryTree tree)
        {
            if (tree == null)
                return -1;

            //early exit if a node's two subtree heights are different by more than one
            //this removes the need to recursively traverse the entire tree
            var leftHeight = getHeight(tree.Left);
            
            //min value is used to denote an unbalanced subtree exists, if we see it, pass it up to the call stack
            //and stop traversing
            if (leftHeight == int.MinValue)
                return int.MinValue;

            var rightHeight = getHeight(tree.Right);

            //stop traversing and pass min value up the call stack
            if (rightHeight == int.MinValue)
                return int.MinValue;

            if (Math.Abs(leftHeight - rightHeight) > 1)
                return int.MinValue;

            //otherwise, return the true height
            return Math.Max(leftHeight, rightHeight) + 1;
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
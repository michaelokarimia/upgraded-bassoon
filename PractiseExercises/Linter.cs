using System;
using System.Collections;
using System.Collections.Generic;

namespace PractiseExercises
{
    internal class Linter
    {
        /// <summary>
        /// Create a linter for C# which ensures that code structures are balanced. Specifically code blocks starting
        /// with { , ( or [.
        /// </summary>



        internal static void Run()
        {
            bool IsBalanced = false;

            //read the string of code

            var sample = samplecode.ToCharArray();
            var code2 = "({plug1}{plug2}(plug1)[plug2]things ([Balanced]) {more(nesting) (){}  here}  end)";

            //sample = code2.ToCharArray();

            IsBalanced = Lint(sample);

            Console.WriteLine("CodeBlock is balanced? {0}", IsBalanced);
        }

        //O(n) complexity, O(n) space
        private static bool Lint(char[] sample)
        {
            bool IsBalanced = false;

            var expected = new Stack<char>();

            //if char equals a bracket char, add it's closing version to a stack

            foreach (char letter in sample)
            {
                if (letter.Equals('('))
                {
                    expected.Push(')');
                }
                if (letter.Equals('['))
                {
                    expected.Push(']');
                }

                if (letter.Equals('{'))
                {
                    expected.Push('}');
                }

                //check for closing bracket and pop the stack.
                //if the popped item is not equal to the closing bracket the 
                //code block is not balanced

                if (letter.Equals(')') || letter.Equals(']') || letter.Equals('}'))
                {
                    //if case the first char is a closing bracket return false immediately 
                    if (expected.Count == 0)
                    { return false; }

                    var actual = expected.Pop();

                    if (actual != letter)
                    {
                        //since we are adding the expected closing bracket to the stack, if they don't match then code is not balanced
                        //exit early
                        return false;
                    }
                }
            }

            //scanned the whole array

            
            if (expected.Count == 0)
            {
                //all cases checked, and stack has been popped 
                return true;
            }

            //there are remainging 
            return IsBalanced;
        }


        static string samplecode = @"
namespace data_structure_tests
{
    [TestFixture]
    public class BinaryTreeTests
    {
        [Test]
        public void ReturnsItsValue()
        {
            var subject = new BinaryTree(9);

            Assert.That(subject.Value, Is.EqualTo(9));
        }


        [Test]
        public void AddsToLeftNode()
        {
            BinaryTree btree = new BinaryTree(1);

            btree.AddLeft(2);

            Assert.That(btree.LeftTree.Value, Is.EqualTo(2));
        }

        [Test]
        public void AddsToRightNode()
        {
            BinaryTree btree = new BinaryTree(1);

            btree.AddRight(3);
            Assert.That(btree.RightTree.Value, Is.EqualTo(3));

        }

        [Test]
        public void BuildsAThreeNodeTree()
        {
            var btree = new BinaryTree(5);

            btree.AddLeft(4);
            btree.AddRight(10);

            Assert.That(btree.Value, Is.EqualTo(5));
            Assert.That(btree.LeftTree.Value, Is.EqualTo(4));
            Assert.That(btree.RightTree.Value, Is.EqualTo(10));

        }


        [Test]
        public void BuildsABalancedTree()
        {
            var root = new BinaryTree(5);

            var l1 = root.AddLeft(3);
            l1.AddLeft(2);

            l1.AddRight(4);

            var r1 = root.AddRight(7);
            
            r1.AddLeft(6);

            r1.AddRight(8);


            Assert.That(root.Value, Is.EqualTo(5));

            Assert.That(root.LeftTree.Value, Is.EqualTo(3));
            Assert.That(root.LeftTree.LeftTree.Value, Is.EqualTo(2));
            Assert.That(root.LeftTree.RightTree.Value, Is.EqualTo(4));



            Assert.That(root.RightTree.Value, Is.EqualTo(7));
            Assert.That(root.RightTree.LeftTree.Value, Is.EqualTo(6));
            Assert.That(root.RightTree.RightTree.Value, Is.EqualTo(8));


        }
    }
}
";
    }
}



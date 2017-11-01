using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace PractiseExercises
{
    internal class QueueWithTwoStacks
    {
        internal static void Run()
        {
            
        }
    }



    [TestFixture]
    public class QueueWithTwoStacksTests
    {
        private OkarimiaQueue<int> subject;

        [SetUp]
        public void Setup()
        {
            subject = new OkarimiaQueue<int>();
        }

        [Test]
        public void EmptyQueueThrowsExceptionForWitheDequeuing()
        {
            
            Assert.Throws<InvalidOperationException>(() => subject.Dequeue());
        }

        [Test]
        public void EnqueueItemAndDequeueIt()
        {
            var inputInt = 1;

            subject.Enqueue(inputInt);
            var result = subject.Dequeue();

            Assert.That(result, Is.EqualTo(inputInt));
        }

        [Test]
        public void EnqueueTwoItemsAndDequeueTheFirst()
        {
            var firstInt = 1;
            var secondInt = 2;

            subject.Enqueue(firstInt);
            subject.Enqueue(secondInt);
            var result = subject.Dequeue();

            Assert.That(result, Is.EqualTo(firstInt));
        }

        [Test]
        public void EnqueueTwoItemsAndDequeueThemBoth()
        {
            var firstInt = 1;
            var secondInt = 2;

            subject.Enqueue(firstInt);
            subject.Enqueue(secondInt);
            var result = subject.Dequeue();

            Assert.That(result, Is.EqualTo(firstInt));

            Assert.That(subject.Dequeue(), Is.EqualTo(secondInt));

        }

    }

    internal class OkarimiaQueue<T>
    {
        private int Count;
        private readonly T Value;
        private readonly Stack<T> tailStack;
        private readonly Stack<T> headStack;

        //do I need a head and tail fields?

        public OkarimiaQueue()
        {
            Count = 0;

            tailStack = new Stack<T>();
            headStack = new Stack<T>();
        }


        internal T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            Count--;
            var result = headStack.Pop();

            if (headStack.Count == 0 && tailStack.Count > 0)
            {
                //pull the bottom of tail stack into the headstack
                if(tailStack.Count == 1)
                {
                    headStack.Push(tailStack.Pop());
                }

            }

            return result;
            
        }

        internal void Enqueue(T value)
        {

            if (headStack.Count == 0)
            {//if headstack is empty just push it there
                headStack.Push(value);
            }
            else
            { //headstack is has items. 

                //if tailstack is empty just push new value there
                if (tailStack.Count == 0)
                {
                    tailStack.Push(value);
                }
                else
                { //both head and tail have items

                    //add the top of the tail stack to the bottom of the head stack

                    var topOfTail = tailStack.Pop();

                    var topOfHead = headStack.Pop();

                    headStack.Push(topOfTail);
                    headStack.Push(topOfHead);

                    //now push the new value to the tailstack
                    tailStack.Push(value);
                }
            }

            Count++;
        }
    }
}
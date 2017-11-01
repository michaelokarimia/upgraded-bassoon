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

        [Test]
        public void EnqueueFourItemsAndDequeueThemAll()
        {
            var firstInt = 1;
            var secondInt = 2;
            var thirdInt = 3;
            var fourthInt = 4;

            subject.Enqueue(firstInt);
            subject.Enqueue(secondInt);
            subject.Enqueue(thirdInt);
            subject.Enqueue(fourthInt);


            Assert.That(subject.Dequeue, Is.EqualTo(firstInt));

            Assert.That(subject.Dequeue(), Is.EqualTo(secondInt));
            Assert.That(subject.Dequeue(), Is.EqualTo(thirdInt));
            Assert.That(subject.Dequeue(), Is.EqualTo(fourthInt));


        }


        [Test]
        public void EnqueueAndDequueFourItems()
        {
            var firstInt = 1;
            var secondInt = 2;
            var thirdInt = 3;
            var fourthInt = 4;

            subject.Enqueue(firstInt);
            subject.Enqueue(secondInt);

            Assert.That(subject.Dequeue, Is.EqualTo(firstInt));

            Assert.That(subject.Dequeue(), Is.EqualTo(secondInt));
            subject.Enqueue(thirdInt);
            subject.Enqueue(fourthInt);
            Assert.That(subject.Dequeue(), Is.EqualTo(thirdInt));
            Assert.That(subject.Dequeue(), Is.EqualTo(fourthInt));


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

            T result;

            Count--;

            if (headStack.Count > 0)
            {
                result = headStack.Pop();
            }
            else //headstack is empty and must be filled from tailstack
            {
                //reverse the entire of tailstack into headstack
                while(tailStack.Count > 0)
                {
                    headStack.Push(tailStack.Pop());
                }

                result = headStack.Pop();
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

                tailStack.Push(value);

            }

            Count++;
        }
    }
}
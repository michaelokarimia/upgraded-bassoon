using System;
using System.Collections.Generic;

namespace PractiseExercises
{
    internal class K_ListsSmallestRange
    {
        internal static void Run()
        {
            /* Given k lists of sorted integers. Find the smallest range that inclues at least one number from each of the
             * k lists
             */

            var input = new List<List<int>>()
            {
                new List<int> { 4, 10, 15, 24, 26},
                new List<int> { 0 , 9 , 12, 20 },
                new List<int> { 5, 18, 22,30}
            };

            var outputList = GetSmallestRange(input);
            foreach (int i in outputList)
            {
                Console.WriteLine(i + ",");
            }
        }

        //Decorates a k list to allow traversal, and for it to remember its current index
        //holds it's current index for the list
        //Value returns the value at list[currentIndex]
        //moveNext() increments currentIndex and returns currentIndex, or NULL if currentIndex can not be incremented(end of list)
        public class RangeList
        {
            public RangeList(List<int> array)
            {
                this.list = array;
                this.currentIndex = 0;

            }
            //returns the value at the current index
            public int Value()
            {
                return list[currentIndex];
            }

            //increment the currentindex of the list, if there are more elements, otherwise return null
            //can be used to check if current list if at the end or not
            public int? moveNext()
            {
                if (currentIndex == list.Count - 1)
                    return null;

                currentIndex++;

                return currentIndex;
            }

            public List<int> list { get; }
            public int currentIndex { get; private set; }
        }


        private static int[] GetSmallestRange(List<List<int>> input)
        {
            var smallestRange = new int[2];

            var minDiffRange = int.MaxValue;
   

            List<RangeList> rangeLists = new List<RangeList>();
            //Rangelist decorates each k lists with a current index and an iterator that allows for traversal
            //for each list add it a RangeList lists
            foreach (List<int> list in input)
            {
                rangeLists.Add(new RangeList(list));
            }

            bool isPossibleNext = true;

            while (isPossibleNext)
            {
                //represents that elements are being compared and need their range calculated
                List<WorkingList> currentWorkingList = new List<WorkingList>();

                //load up the workingList
                foreach (RangeList rl in rangeLists)
                {
                    currentWorkingList.Add(new WorkingList( rl.Value(), rl));
                }
                
                //now to calculate the candidate range between the lists.


                //sort by value of the smallest current val first. Only care about the list with the smallest val
                //sorting this way means we only increment the list with the lowest value
                currentWorkingList.Sort();

                //get the smallest number of all the lists
                var smallest = currentWorkingList[0].val;

                //since this has been sorted, get the largest number of the lists
                var largest = currentWorkingList[currentWorkingList.Count - 1].val;

                var potentialmin = largest - smallest + 1; //zero based arrays, so add one each time.
                
                //if this range is smaller than the last known smallest range, replace it and store the values 
                if(potentialmin < minDiffRange)
                {
                    minDiffRange = potentialmin;
                    smallestRange = new int[] { smallest, largest };
                }
                //if there is another value in the list then iterate, otherwise we are done so exit loop
                //if there is no more items in the list with the smallest number, then we're done
                isPossibleNext = currentWorkingList[0].list.moveNext() != null;
            }

            return smallestRange;
        }

        //datastructure that represents the list we are comparing
        public struct WorkingList :IComparable
        {
            public WorkingList(int value, RangeList rangeList)
            {
                val = value;
                list = rangeList;
            }

            public RangeList list { get; }
            public int val { get; }

            //allows us to sort a list of working lists by the value
            public int CompareTo(object obj)
            {
                WorkingList comparator = (WorkingList)obj;

                return val.CompareTo(comparator.val);
            }
        }
    }
}
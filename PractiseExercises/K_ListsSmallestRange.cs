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
                new List<int> { 0 ,9 , 12, 20 },
                new List<int> { 5, 18, 22, 30}
            };

            var outputList = GetSmallestRange(input);
            foreach (int i in outputList)
            {
                Console.WriteLine(i + ",");
            }
        }

        //represents a value at an index of a lists. Can iterate along the list for all indexes
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

            //iterate the index of the list, if there are more elements, otherwise return null
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
   

            //data structure to hold the range of elements in every list
            List<RangeList> rangeLists = new List<RangeList>();

            //for each list add it a RangeListArray
            foreach (List<int> list in input)
            {
                rangeLists.Add(new RangeList(list));
            }

            bool isPossibleNext = true;

            while (isPossibleNext)
            {
                List<WorkingList> currentWorkingList = new List<WorkingList>();

                //iterate through each rangelist and add them to a workingList
                foreach (RangeList rl in rangeLists)
                {
                    currentWorkingList.Add(new WorkingList( rl.Value(), rl));
                }

                currentWorkingList.Sort();

                var first = currentWorkingList[0].val;
                var last = currentWorkingList[currentWorkingList.Count - 1].val;
                var potentialmin = last - first + 1;

                if(potentialmin < minDiffRange)
                {
                    minDiffRange = potentialmin;
                    smallestRange = new int[] { first, last };
                }

                isPossibleNext = currentWorkingList[0].list.moveNext() != null;
            }

            return smallestRange;
        }

        public struct WorkingList :IComparable
        {
            public WorkingList(int value, RangeList rangeList)
            {
                val = value;
                list = rangeList;
            }

            public RangeList list { get; }
            public int val { get; }

            public int CompareTo(object obj)
            {
                WorkingList comparator = (WorkingList)obj;

                return val.CompareTo(comparator.val);
            }
        }
    }
}
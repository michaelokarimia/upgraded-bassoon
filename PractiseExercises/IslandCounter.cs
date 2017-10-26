using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseExercises
{
    /***
    Given a 2d grid map of ‘1’s (land) and '0’s (water), count the number of islands.
    An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
    You may assume all four edges of the grid are all surrounded by water.

    // Example 1:
    const ocean = [
        [1,1,1,1,0],
        [1,1,0,1,0],
        [1,1,0,0,0],
        [0,0,0,0,0]
    ];
    //Answer: 1

    //Example 2:
    const ocean2 = [
      [1,1,0,0,0],
      [1,1,0,0,0],
      [0,0,1,0,0],
      [0,0,0,1,1]
    ];
    //Answer: 3
 
     */

    public class IslandCounter
    {
        //one island
        static int[][] map1 = new int[][] {
         new int[]{ 1,1,1,1,0 },
         new int[]{ 1,1,0,1,0 },
         new int[]{ 1,1,0,0,0 },
         new int[]{ 0,0,0,0,0 }
        };

        //three islands
        static int[][] map2 = new int[][] {
         new int[]{ 1,1,0,0,0 },
         new int[]{ 1,1,0,0,0 },
         new int[]{ 0,0,1,0,0 },
         new int[]{ 0,0,0,1,1 }
        };


        //two islands
        static int[][] map3 = new int[][] {
         new int[]{ 1,1,0,0,0 },
         new int[]{ 1,1,0,0,0 },
         new int[]{ 0,0,1,0,1 },
         new int[]{ 0,0,1,1,1 }
        };

        //one island
        static int[][] map4 = new int[][] {
         new int[]{ 0,0,0,1,1 },
         new int[]{ 0,0,0,0,1 },
         new int[]{ 0,0,0,1,1 },
         new int[]{ 0,0,0,0,0 }
        };


        public static void  Run()
        {
            IslandCounter counter = new IslandCounter();

            int islandCount = counter.getIslandCount(map3);

            Console.WriteLine("There are {0} islands", islandCount);

        }


        public class Point
        {
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public int x;
            public int y;
        }

        private int getIslandCount(int[][] map)
        {
            if(map ==null || map.Length < 2 || map[0].Length < 2)
            {
                throw new Exception("Invalid map dimension");
            }
            int foundIslandCount = 0;

            //an island is a collection of elements with the value 1 connected NESW to another 1.
            //can be represented as a linked list

            //traverse each element of a map searching for unexplored land.

            //If element value = 1 it's unexplored land 


            //chart that land, checking NESW to get all the contigious land, until there is no more connected land
            //set the value of the coordinate of the discovered land on the map to 2, so we don't count it twice.

            //Each coordinate should be added to linked list. Push these coordinates into a stack 
            //once all connected land has been checked, exit method 


            //Then traverse the next coordinate on the map, till you reach the end.

            var start = new Point(0, 0);


            while((start = getUnchartedCoordinates(start,map)) != null)
            {
                markIslandAsVisited(map, start);

                foundIslandCount++;
            }

            
            return foundIslandCount;
        }

        private void markIslandAsVisited(int[][] map, Point start)
        {
            Stack<Point> toVist = new Stack<Point>();

            toVist.Push(start);

            //check all points to visit
            while (toVist.Count > 0)
            {
                var current = toVist.Pop();

                //if N is uncharted and not at the N edge of map, then add to list of exploration
                if (current.y > 0 && map[current.y - 1][current.x] == 1)
                {
                    toVist.Push(new Point(current.x, current.y - 1));
                }

                //if E is uncharted, and not at the E edge of map, then add to list of exploration
                if (current.x < map[current.y].Length-1 && map[current.y][current.x + 1] == 1)
                {
                    toVist.Push(new Point(current.x + 1, current.y));
                }

                //if S is uncharted, and not at the S edge of map, then add to list of exploration
                if (current.y < map.Length-1 && map[current.y+1][current.x] == 1)
                {
                    toVist.Push(new Point(current.x, current.y + 1));
                }

                //if W is uncharted and not at the W edge of map, the add to list of exploration
                if(current.x > 0 && map[current.y][current.x-1] == 1)
                {
                    toVist.Push(new Point(current.x - 1, current.y));
                }

                //mark coord as visited
                map[current.y][current.x] = 2;

            }
        }

        //given the map and start point, traverse every element on the map
        //return the point coordinate if there is uncharted land
        //else null when whole map has been charted
        private static Point getUnchartedCoordinates(Point start, int[][] map)
        {
            for(int i = start.y; i< map.Length; i++)
            {
                for (int j = start.x; j < map[i].Length; j++)
                {
                    if (map[i][j] == 1)
                    { return new Point(j, i); }
                }
            }

            return null;
        }
    }
}

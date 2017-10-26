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
        static int[][] map1 = new int[][] {
         new int[]{ 1,1,1,1,0 },
         new int[]{ 1,1,0,1,0 },
         new int[]{ 1,1,0,0,0 },
         new int[]{ 0,0,0,0,0 }
        };

        static int[][] map2 = new int[][] {
         new int[]{ 1,1,0,0,0 },
         new int[]{ 1,1,0,0,0 },
         new int[]{ 0,0,1,0,0 },
         new int[]{ 0,0,0,1,1 }
        };

        public static void Run()
        {
            int islandCount = getIslandCount(map2);

            Console.WriteLine("There are {0} islands", islandCount);

        }

        private static int getIslandCount(int[][] map)
        {
            if(map ==null || map.Length < 2 || map[0].Length < 2)
            {
                throw new Exception("Invalid map dimension");
            }
            int foundIslandCount = 0;

            //traverse each element, 

            //If element value = 1 it's land

            //as we scan the array from left to right and top to bottom, if current element is land and north or west element
            //is land, then we are on contigious land i.e. the same island.

            //should there be land and both north and west are ocean, then there is another island so increment island count

            //nestedloop, O(n^2) complexity
            for (int j = 0; j < map.Length; j++)
            {
                //j represents each row

                //i represents each column
                for (int i = 0; i < map[j].Length; i++)
                {
                    //it's land
                    if (map[j][i].Equals(1))
                    {
                        bool landToNorth, LandToWest;

                        //check north
                        //if j = 0 then north of it will be ocean
                        if (j == 0)
                        {
                            landToNorth = false;
                        }
                        else
                        {
                            landToNorth = (map[j - 1][i].Equals(1));
                        }
                        
                        //checkwest
                        //if i is 0 then we are at the west edge and ocean is to the west
                        if(i == 0)
                        {
                            LandToWest = false;
                        }
                        else
                        {
                            LandToWest = map[j][i - 1].Equals(1);
                        }

                        //if there is no land north or west of current, then we have found a new island
                        if(!landToNorth && !LandToWest)
                        {
                            foundIslandCount++;
                        }
                    }
                }

            }

            return foundIslandCount;
        }
    }
}

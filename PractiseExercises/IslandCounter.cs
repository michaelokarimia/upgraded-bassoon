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
        static int[][] ocean1 = new int[][] {
         new int[]{1, 1, 1, 1, 0 },
         new int[]{1, 1, 0, 1, 0 },
         new int[]{1, 1, 0, 0, 0 },
         new int[]{0, 0, 0, 0, 0 }
        };

        static int[][] ocean2 = new int[][] {
         new int[]{1,1,0,0,0 },
         new int[]{1,1,0,0,0 },
         new int[]{0,0,1,0,0 },
         new int[]{ 0, 0, 0, 1, 1 }
        };

        public static void Run()
        {
            int islandCount = getIslandCount(ocean1);

            Console.WriteLine("There are {0} islands", islandCount);

        }

        private static int getIslandCount(int[][] ocean)
        {
            if(ocean ==null || ocean.Length < 2 || ocean[0].Length < 2)
            {
                throw new Exception("Invalid ocean dimension");
            }
            int foundIslandCount = 0;

            //traverse each element, 

            //If element value = 1 it's land so check 
            //checking North, South, East, West for 0  whihc is ocean. If true, then increment island count


            //nestedloop, O(n^2) complexity
            for (int j = 0; j < ocean.Length; j++)
            {
                //j represents each row

                //i represents each column
                for (int i = 0; i < ocean[j].Length; i++)
                {
                    //it's land
                    if (ocean[j][i].Equals(1))
                    {
                        bool oceanToNorth, oceanToEast, oceanToSouth, oceanToWest;

                        //check north
                        //if j = 0 then north of it will be ocean
                        if (j == 0)
                        {
                            oceanToNorth = true;
                        }
                        else
                        {
                            oceanToNorth = (ocean[j - 1][i].Equals(0));
                        }
                        
                        //check if ocean to east
                        //if at easternmost edge, then it's true
                        if (i == ocean[j].Length-1)
                        {
                            oceanToEast = true;
                        }
                        else
                        {
                            oceanToEast = (ocean[j][i + 1].Equals(0));
                        }

                        //check if ocean to south
                        // if j is at the length then it is ocean

                        if(j == ocean.Length -1)
                        {
                            oceanToSouth = true;
                        }
                        else
                        {
                            oceanToSouth = ocean[j + 1][i].Equals(0);
                        }

                        //checkwest
                        //if i is 0 then we are at the edge and ocean is to the west
                        if(i == 0)
                        {
                            oceanToWest = true;
                        }
                        else
                        {
                            oceanToWest = ocean[j][i - 1].Equals(0);
                        }


                        if(oceanToNorth && oceanToEast && oceanToSouth && oceanToWest)
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

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
        static int[][] ocean = new int[][] {
         new int[]{1, 1, 1, 1, 0 },
         new int[]{1, 1, 0, 1, 0 },
         new int[]{1, 1, 0, 0, 0 },
         new int[]{0, 0, 0, 0, 0 }
        }
        ;

        public static void Run()
        {
            int islandCount = getIslandCount(ocean);

            Console.WriteLine("There are {0} islands", islandCount);

        }

        private static int getIslandCount(int[][] ocean)
        {
            if(ocean ==null || ocean.Length < 2 || ocean[0].Length < 2)
            {
                throw new Exception("Invalid ocean dimension");
            }


            int count = 0;


            return count;
        }
    }
}

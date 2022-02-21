using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems
{
    public class TrappingRainWater
    {
        public int Calculate(int[] data)
        {
            var tappedWater = 0;
            var leftWallHeight = 0;
            var currentTapperWater = 0;
            foreach (var wall in data)
            {
                if (leftWallHeight > 0 && wall < leftWallHeight)
                {
                    currentTapperWater += (leftWallHeight - wall);
                }
                else if (leftWallHeight > 0 && wall >= leftWallHeight)
                {
                    tappedWater += currentTapperWater;
                    currentTapperWater = 0;
                    leftWallHeight = wall;
                }
            //    else if (currentHeight > 0 && wall < currentHeight)
            //    {
                    
            //    }
            //    if (wall > 0)
            //    {
            //        currentHeight = wall;
            //    }
            //    if (wall > currentHeight)
            //    {
                    
            //    }
            }

            return tappedWater;
        }
    }
}

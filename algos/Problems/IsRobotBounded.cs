using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems
{
    public class IsRobotBoundedAlgo
    {
        //https://cybergeeksquad.co/2021/06/robot-bounded-in-circle-solution-amazon-oa.html
        public bool IsRobotBounded(String instructions)
        {
            // init position
            int[] pos = new int[] { 0, 0 };

            // directions north, east, south, west 
            var dirs = new int[][]{ new int[]{ 0, 1 }, new int[]{ 1, 0 }, new int[]{ 0, -1 }, new int[]{ -1, 0 } };

            int face = 0;
            var ins = instructions.ToCharArray();

            foreach (char c in ins)
            {
                if (c == 'L')
                {
                    face = face == 0 ? 3 : face - 1;
                }
                else if (c == 'R')
                {
                    face = face == 3 ? 0 : face + 1;
                }
                else
                {
                    pos[0] = pos[0] + dirs[face][0];
                    pos[1] = pos[1] + dirs[face][1];
                }
            }
            return (face != 0 || (pos[0] == 0 && pos[1] == 0));
        }
    }
}

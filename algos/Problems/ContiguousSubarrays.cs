using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems
{
    public class ContiguousSubarrays
    {
        public static int[] Find(int[] arr)
        {
            Stack<int> onboard = new Stack<int>();

            // Once we drop off the index from the stack we'll sum up the steps it traveled here.
            int[] ways = new int[arr.Length];

            // Train's moving from L to R, picking up indices and carrying as max on left
            for (int i = 0; i < arr.Length; i++)
            {

                // Drop off everyone that is too small
                while (onboard.Count() > 0 && arr[i] > arr[onboard.Peek()])
                {
                    // dismounted is the index where this one started to travel with us.
                    int dismounted = onboard.Pop();
                    // Count how many steps this one travelled
                    ways[dismounted] = i - dismounted;
                }

                // Pick up this index.
                onboard.Push(i);
            }

            // Drop off everyone that stayed on for the whole ride.
            while (onboard.Count() > 0)
            {
                int dismounted = onboard.Pop();
                ways[dismounted] = arr.Length - dismounted;
            }


            // Train's moving from R to L, reverse of above... with max on right
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                // We'll always count one index as we did above, so don't double count it.
                ways[i]--;

                // Drop off everyone that is too small
                while (onboard.Count()> 0 && arr[i] > arr[onboard.Peek()])
                {
                    // dismounted is the index where this one started to travel with us.
                    int dismounted = onboard.Pop();
                    // Count how many steps this one travelled
                    ways[dismounted] += dismounted - i;
                }
                onboard.Push(i);
            }

            // Drop off everyone that stayed on for the whole ride.
            while (onboard.Count() > 0)
            {
                int dismounted = onboard.Pop();
                ways[dismounted] += dismounted + 1;
            }
            return ways;
        }

    }
}

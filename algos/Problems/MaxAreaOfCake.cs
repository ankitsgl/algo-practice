using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems;

public class MaxAreaOfCake
{
    //https://leetcode.com/problems/maximum-area-of-a-piece-of-cake-after-horizontal-and-vertical-cuts/
    public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
    {
        // Start by sorting the inputs
        Array.Sort(horizontalCuts);
        Array.Sort(verticalCuts);
        int n = horizontalCuts.Length;
        int m = verticalCuts.Length;

        // Consider the edges first
        long maxHeight = Math.Max(horizontalCuts[0], h - horizontalCuts[n - 1]);
        for (int i = 1; i < n; i++)
        {
            // horizontalCuts[i] - horizontalCuts[i - 1] represents the distance between
            // two adjacent edges, and thus a possible height
            maxHeight = Math.Max(maxHeight, horizontalCuts[i] - horizontalCuts[i - 1]);
        }

        // Consider the edges first
        long maxWidth = Math.Max(verticalCuts[0], w - verticalCuts[m - 1]);
        for (int i = 1; i < m; i++)
        {
            // verticalCuts[i] - verticalCuts[i - 1] represents the distance between
            // two adjacent edges, and thus a possible width
            maxWidth = Math.Max(maxWidth, verticalCuts[i] - verticalCuts[i - 1]);
        }

        // Be careful of overflow, and don't forget the modulo!
        return (int)((maxWidth * maxHeight) % (1000000007));
    }
}

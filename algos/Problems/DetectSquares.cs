using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems;

public class DetectSquares
{
    Dictionary<(int x, int y), int> Points = new Dictionary<(int x, int y), int>();
    public DetectSquares()
    {

    }

    public void Add(int[] point)
    {

        Points[(point[0], point[1])] =  Points.GetValueOrDefault((point[0], point[1]), 0) + 1;
    }

    public int Count(int[] point)
    {
        var result = 0;
        var x = point[0];
        var y = point[1];
        foreach (var loc in Points.Keys)
        {
            //check if a diagonal point exist whis is having x and y distance as same
            if (Math.Abs(loc.x - x) != 0 && Math.Abs(loc.x - x) == Math.Abs(loc.y - y))
            {
                //take y of diagonal and x of current point
                var leftCoordinate = (loc.x, y);
                //take x of diagonal and y of current point
                var rightCoordinate = (x, loc.y);
                result += Points.GetValueOrDefault(leftCoordinate, 0)
                    * Points.GetValueOrDefault(rightCoordinate, 0);
            }
        }
        return result;
    }
}

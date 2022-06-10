using algos.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Sort;
public class MergeSort
{

    public int[] Sort(int[] array)
    {
        if (array.Length == 1)
            return array;

        // Use devide and concur
        var middle = array.Length / 2;
        var left = array.Take(new Range(0, middle)).ToArray();
        var right = array.Take(new Range(array.Length - middle, array.Length )).ToArray();

        ArrayHelper.PrintArray(left, "Left: ");

        ArrayHelper.PrintArray(right, "Right: ");

        return Merge(Sort(left), Sort(right));
    }

    private int[] Merge(int[] left, int[] right)
    {
        var result = new int[left.Length + right.Length];
        var i = 0;
        var leftIndex = 0;
        var rightIndex = 0;

        // Merge two array in order like merge linked list. array may not be sorted allways.
        while (leftIndex < left.Length && rightIndex < right.Length)
        {
            if (left[leftIndex] < right[rightIndex])
            {
                result[i++] = left[leftIndex++];
            }
            else
            {
                result[i++] = right[rightIndex++];
            }
        }
        
        for (;leftIndex < left.Length;leftIndex++)
            result[i++] = left[leftIndex];

        for (; rightIndex < right.Length; rightIndex++)
            result[i++] = right[rightIndex];

        return result;
    }
}
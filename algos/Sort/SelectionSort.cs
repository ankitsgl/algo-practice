using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Sort
{
    public class SelectionSort
    {

        public int[] Sort(int[] array)
        {
            for (var i = 0; i < array.Length-1; i++)
            {

                // Search min and update it in i
                var smallestIndex = i;
                for (var j = i; j < array.Length; j++)
                {   
                    if (array[j] < array[smallestIndex])
                    {
                        smallestIndex = j;                        
                    }
                }
                var temp = array[i];
                array[i] = array[smallestIndex];
                array[smallestIndex] = temp;
            }
            return array;
        }
    }
}

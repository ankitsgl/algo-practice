using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems
{
    public  class ReverseToMakeEqual
    {
        public bool CanBeEqual(int[] target, int[] arr)
        {
            return Check(target, arr);
        }

        public bool CheckTwo(int[] target, int[] arr)
        {
            // Check if same value exists in both awway and exact same number of times. 
            if (target.Length != arr.Length) // if not equal, immediatly return
                return false;

            var map = new Dictionary<int, int>();
            for (int i = 0; i < target.Length; i++)
            {
                // Increment by one
                if (map.ContainsKey(target[i]))
                    map[target[i]]++;
                else
                    map.Add(target[i], 1);
                // Decrement by one
                if (map.ContainsKey(arr[i]))
                    map[arr[i]]--;
                else
                    map.Add(arr[i], -1);
            }
            // Go through all of the values in the dictionary
            // If any is not 0 it means they are not equal
            foreach (var m in map)
            {
                if (m.Value != 0)
                    return false;
            }

            return true;
        }
        public bool Check(int[] arrayA, int[] arrayB)
        {

            if (arrayA.Length != arrayB.Length)
            {
                return false;
            }

            var startIndex = -1;
            var endIndex = arrayA.Length - 1;

            // Find non matching start end 
            for (int i = 0; i < arrayA.Length; i++)
            {
                if (startIndex == -1 && arrayA[i] != arrayB[i])
                {
                    startIndex = i;
                }
                if (startIndex >= 0 && arrayA[i] == arrayB[i])
                {
                    endIndex = i-1;
                }
            }

            if (endIndex - startIndex < 1) return false;

            for (int i = startIndex; i <= endIndex; i++)                       
            {
                if (arrayA[i] != arrayB[endIndex - (i-startIndex)]) return false;
                ///startIndex++;
                //endIndex--;
            }

            return true;
        }
    }
}

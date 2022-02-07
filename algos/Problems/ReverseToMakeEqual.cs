using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems
{
    public  class ReverseToMakeEqual
    {
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

namespace algos.Problems
{
    using System;

    public static class ReverseString
    {
        public static string Reverse(string str)
        { 
            var array = str.ToCharArray();
            
            var j = array.Length-1;
            for (var i = 0; i < array.Length / 2; i++, j--)
            {
                var tem = array[j];
                array[j] = array[i];
                array[i] = tem;
            }
            str = new string(array);
            return str;
        }
    }
}

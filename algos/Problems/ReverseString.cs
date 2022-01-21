using System;
using System.Collections.Generic;
using System.Text;

namespace algos
{
    public static class ReverseString
    {
        public static void Run()
        {
            Reverse("Hello I am Ankit Singhals");
            Console.WriteLine("Done....");
            Console.Read();
        }

        static void Reverse(string str)
        {   
            Console.WriteLine($"String : {str}");
            var array = str.ToCharArray();
            
            var j = array.Length-1;
            for (var i = 0; i < array.Length / 2; i++, j--)
            {
                var tem = array[j];
                array[j] = array[i];
                array[i] = tem;
            }
            str = new string(array);
            Console.WriteLine($"Reversed String : {str}");
        }
    }
}

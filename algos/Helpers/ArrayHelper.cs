using System;

namespace algos.Helpers;

public class ArrayHelper
{
    public static void PrintArray<T>(T[][] array)
    {
        for (var i = 0; i < array.Length; i++)
        {
            Console.Write("| ");
            foreach (var t in array[i])
            {
                Console.Write(t.ToString().PadRight(3) + "| ");
            }
            Console.WriteLine();
        }
    }

    public static bool AreEqual<T>(T[][] first, T[][] second)
    {
        if (first.Length != second.Length) return false;

        for (var i = 0; i < first.Length; i++)
        {
            if (first[i].Length != second[i].Length) return false;
            for (var j = 0; j < first[i].Length; j++)
            {
                if (first[i][j].ToString() != second[i][j].ToString()) return false;
            }
        }
        return true;
    }
}

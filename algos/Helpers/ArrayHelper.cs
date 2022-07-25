using System;

namespace algos.Helpers;

public class ArrayHelper
{
    public static void PrintArray<T>(T[][] array)
    {
        Console.Write("X : ");
        for (var i = 0; i < array[0].Length; i++)
        {
            Console.Write(i.ToString().PadRight(3) + ": ");
        }
        Console.WriteLine();
        Console.WriteLine("----------------------");
        for (var i = 0; i < array.Length; i++)
        {
            Console.Write(i + " : ");
            foreach (var t in array[i])
            {
                Console.Write(t.ToString().PadRight(3) + "| ");
            }
            Console.WriteLine();
        }
    }

    public static void PrintArray<T>(IList<IList<T>> list)
    {
        for (var i = 0; i < list.Count; i++)
        {
            Console.Write(i + " : ");
            foreach (var t in list[i])
            {
                Console.Write(t.ToString().PadRight(3) + ", ");
            }
            Console.WriteLine();
        }
    }

    public static void PrintArray<T>(List<List<T>> list)
    {
        for (var i = 0; i < list.Count; i++)
        {
            Console.Write(i + " : ");
            foreach (var t in list[i])
            {
                Console.Write(t.ToString().PadRight(3) + ", ");
            }
            Console.WriteLine();
        }
    }

    public static void PrintArray(int[] array, string prefix = "")
    {
        Console.Write(prefix);
        foreach (var item in array)
            Console.Write($"{item}, ");
        Console.WriteLine();
    }

    public static void PrintArrayMatrix(int[] array, string header = "")
    {
        Console.WriteLine(header);
        for (var i = 0; i < array.Length; i++)
            Console.WriteLine($"{i}     : {array[i]}");
        Console.WriteLine();
    }

    public static void PrintArray(List<int> array, string prefix = "")
    {
        Console.Write(prefix);
        foreach (var item in array)
            Console.Write($"{item}, ");
        Console.WriteLine();
    }

    public static void PrintArray(IList<string> array, string prefix = "")
    {
        Console.Write(prefix);
        foreach (var item in array)
            Console.Write($"{item}, ");
        Console.WriteLine();
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

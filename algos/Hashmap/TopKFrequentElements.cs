using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.Hashmap;

public class TopKFrequentElements
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var result = new int[k];
        var map = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            var count = map.GetValueOrDefault(num, 0);
            map[num] = ++count;
        }

        var pQueue = new PriorityQueue<int, int>();
        // Lowest value is highest priority
        foreach(var item in map)
            pQueue.Enqueue(item.Key, item.Value*-1);

        for (var index = 0; index < k; index++)
            if (pQueue.Count> 0 ) result[index] = pQueue.Dequeue();


        return result;
    }
}

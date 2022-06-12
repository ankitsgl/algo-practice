using algos.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Graph;
public class WordLadder
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        // Check if end word is not in list.
        if (!wordList.Contains(endWord))
            return 0;

        var neighbour = new Dictionary<string, HashSet<string>>();
        wordList.Add(beginWord);
        // Create pattern of each word with possible wildcard *
        foreach (var word in wordList)
        {
            var len = word.Length;
            for (var i = 0; i< len; i++)
            {
                var pattern = word[0..i] + "*" + word[(i + 1)..(len)];                

                if (neighbour.ContainsKey(pattern))
                    neighbour[pattern].Add(word);
                else
                    neighbour.Add(pattern, new HashSet<string>() { word });
            }
        }

        GraphHelper.PrintGraphWithPattern(wordList, neighbour);

        var visited = new HashSet<string>() { beginWord };
        var queue = new Queue<string>(new[] { beginWord });

        
        var result = 1;

        while (queue.Count > 0)
        {
            var queueLength = queue.Count;
            for (var i = 0; i < queueLength; i++)
            {
                var word = queue.Dequeue();
                Console.Write(word + " > ");
                if (word == endWord)
                    return result;

                var len = word.Length;
                for (var j = 0; j < len; j++)
                {
                    var pattern = word[0..j] + "*" + word[(j + 1)..(len)];

                    foreach (var neighbourWord in neighbour.GetValueOrDefault(pattern, new HashSet<string>()) )
                    {
                        if (!visited.Contains(neighbourWord))
                        {
                            visited.Add(neighbourWord);
                            queue.Enqueue(neighbourWord);
                        }
                    }
                    
                }
            }
            if (queue.Count == 1)
                Console.WriteLine();
            result++;
        }
        // Use BFS to search shortest path.

        return 0;
    }
}
using algos.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Graph;
public class WordLadder
{
    #region Word Ladder / Ladder Length
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

    #endregion

    #region Word Ladder 2 / Find Ladder 
    public IList<IList<string>> FindLadders_bf(string beginWord, string endWord, IList<string> wordList)
    {
        var result = new List<IList<string>>();

        var queue = new Queue<List<string>>();
        queue.Enqueue(new List<string> { beginWord });

        var visited =new HashSet<string>();
        var words = new HashSet<string>(wordList);

        while (queue.Count > 0)
        {
            var currentLayerSet = new HashSet<string>();
            var len = queue.Count;
            foreach (var _ in Enumerable.Range(0, len))
            {
                var currList = queue.Dequeue(); 
                var lastWord = currList.Last();
                if ( lastWord == endWord )
                    result.Add(currList);

                // look for next layer 
                foreach (var i in Enumerable.Range(0, beginWord.Length))
                {
                    foreach (char c in Enumerable.Range('a', 'z'))
                    {
                        var nextWord = lastWord[..i] + c + lastWord[(i + 1)..];
                        if (words.Contains(nextWord) && !visited.Contains(nextWord))
                        {
                            queue.Enqueue(currList.Concat(new List<string>() { nextWord }).ToList());
                            currentLayerSet.Add(nextWord);
                        }
                    }
                }
            }
            // Add to Visisted only after current level is processed
            foreach (var word in currentLayerSet)
                visited.Add(word);
        }

        return result;
    }

    public IList<IList<string>> FindLadders_op(string beginWord, string endWord, IList<string> wordList)
    {

        // Create a pattern map
        // Use BFS to traverse current level at 
        // Create a word neibhour map
        // Use DFS to buld the list with possible paths with neighbours 

        var result = new List<IList<string>>();

        var neighbours = new Dictionary<string, HashSet<string>>();
        var possibleEdges = new Dictionary<string, HashSet<string>>();
        if ( !wordList.Contains(beginWord))
            wordList.Add(beginWord);

        var wordLen = beginWord.Length;
        foreach (var word in wordList)
        {
            possibleEdges.Add(word, new HashSet<string>());
            for (var i = 0; i < wordLen; i++)
            {
                var pattern = word[0..i] + "*" + word[(i+1)..];
                if (!neighbours.ContainsKey(pattern))
                    neighbours.Add(pattern, new HashSet<string>());
                neighbours[pattern].Add(word);
            }
        }

        GraphHelper.PrintGraphWithPattern(wordList, neighbours);



        var queue = new Queue<string>() ;
        queue.Enqueue(beginWord);

        var visited = new HashSet<string>();

        while (queue.Count > 0)
        {   
            var queuLen = queue.Count;
            var currentLayer = new HashSet<string>();
            foreach (var _ in Enumerable.Range(0, queuLen))
            {

                var word = queue.Dequeue();

                if (word == endWord)
                    continue;

                foreach (var i in Enumerable.Range(0, beginWord.Length))
                {
                    var pattern = word[0..i] + "*" + word[(i + 1)..];
                    foreach (var edge in neighbours[pattern])
                    {
                        if (!visited.Contains(edge))
                        {
                            if (word != edge )
                                possibleEdges[word].Add(edge);
                            queue.Enqueue(edge);
                            currentLayer.Add(edge);
                        }
                    }
                }
            }
            foreach (var word in currentLayer)
                visited.Add(word);
        }

        GraphHelper.PrintGraph(wordList, possibleEdges);

        void dfs(List<string> path, string word)
        {
            path.Add(word);
            if (word == endWord)
                result.Add(new List<string>(path));
            foreach (var nextWord in possibleEdges[word])
                dfs(path, nextWord);
            path.RemoveAt(path.Count - 1);
        }
        var path = new List<string>();
        dfs(path, beginWord);
        return result;
    }

     
    #endregion
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Trees
{
    public class TrieNode
    {
        public Char Char { get; set; }
        public bool IsWord { get; set; }
        public IDictionary<char, TrieNode> Childerns { get; set; }

        public TrieNode(char chr)
        {
            this.Char = chr;
            Childerns = new Dictionary<char, TrieNode>();
        }
    }
    public class TriePractice
    {
        private TrieNode Root;
        public TriePractice()
        {
            Root = new TrieNode(' ');
        }

        public void AddWord(string word)
        {

            TrieNode node = Root;
            foreach (var chr in word)
            {
                if (!node.Childerns.ContainsKey(chr))
                    node.Childerns.Add(chr, new TrieNode(chr));
                
                node = node.Childerns[chr];
            }
            node.IsWord = true;
        }

        public string[] GetAllWords()
        {
            var result = new List<string>();
            
            GetWords(Root.Childerns, result, new List<char>());
            
            return result.ToArray();
        }

        private void GetWords(IDictionary<char, TrieNode> nodes, List<string> words, List<char> chars)
        {
            foreach (var node in nodes)
            {
                chars.Add(node.Key);
                if (node.Value.IsWord)
                    words.Add(new String(chars.ToArray()));
                    
                if( node.Value.Childerns.Count > 0)
                    GetWords(node.Value.Childerns, words, chars);
                chars.RemoveAt(chars.Count - 1);
            }
        }

        public string[] SearchAllWords(string prefix)
        {
            var result = new List<string>();
            
            
            var node = Root;

            var chars = new List<char>();
            foreach (var chr in prefix)
            {
                chars.Add(chr);
                if (node.Childerns.ContainsKey(chr))
                    node = node.Childerns[chr];
                else
                    return result.ToArray();
            }

            GetWords(node.Childerns, result, chars);
            
            return result.ToArray();
        }
    }
}

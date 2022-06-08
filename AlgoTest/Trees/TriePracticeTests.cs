using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Trees.Tests
{
    [TestClass()]
    public class TriePracticeTests
    {
        [TestMethod()]
        public void AddWordTest()
        {
            var trie = new TriePractice();

            trie.AddWord("are");
            trie.AddWord("as");
            trie.AddWord("dot");
            trie.AddWord("news");
            trie.AddWord("not");
            trie.AddWord("zen");
        }

        [TestMethod()]
        public void GetAllWordsTest()
        {
            var trie = new TriePractice();

            trie.AddWord("are");
            trie.AddWord("as");
            trie.AddWord("dot");
            trie.AddWord("news");
            trie.AddWord("not");
            trie.AddWord("zen");

            var result = trie.GetAllWords();

            Assert.IsNotNull(result);
            Assert.AreEqual(6, result.Length);

            foreach (var word in result)
            {
                Console.WriteLine(word);
            }

            Assert.IsTrue(result.Contains("are"));


            Assert.IsTrue(result.Contains("as"));
            Assert.IsTrue(result.Contains("dot"));
            Assert.IsTrue(result.Contains("news"));
            Assert.IsTrue(result.Contains("not"));
            Assert.IsTrue(result.Contains("not"));
        }


        [TestMethod()]
        public void SearchAllWordsTest()
        {
            var trie = new TriePractice();

            trie.AddWord("are");
            trie.AddWord("as");
            trie.AddWord("dot");
            trie.AddWord("news");
            trie.AddWord("not");
            trie.AddWord("zen");

            var result = trie.SearchAllWords("a");

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Length);

            foreach (var word in result)
            {
                Console.WriteLine(word);
            }

            Assert.IsTrue(result.Contains("are"));
            Assert.IsTrue(result.Contains("as"));
        }
        [TestMethod()]
        public void SearchAllWordsTest2()
        {
            var trie = new TriePractice();

            trie.AddWord("are");
            trie.AddWord("as");
            trie.AddWord("dot");
            trie.AddWord("news");
            trie.AddWord("not");
            trie.AddWord("ankit");
            trie.AddWord("ankita");
            trie.AddWord("ant");
            trie.AddWord("aniket");
            trie.AddWord("singhal");

            var result = trie.SearchAllWords("an");

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Length);

            foreach (var word in result)
            {
                Console.WriteLine(word);
            }

            Assert.IsTrue(result.Contains("aniket"));
            Assert.IsTrue(result.Contains("ankit"));
        }
    }
}
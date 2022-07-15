using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems.Tests
{
    [TestClass()]
    public class EmojiMessageTests
    {
        [TestMethod()]
        public void ReplaceEmojiTest()
        {
            var sol = new EmojiMessage();
            var result = sol.ReplaceEmoji(":)::(:)");
            Console.WriteLine(result);
            Assert.AreEqual("emoji_1:emoji_3", result);
        }
    }
}
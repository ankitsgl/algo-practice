using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using algos.Helpers;

namespace algos.Problems.Tests
{
    [TestClass()]
    public class FrequentKPagesGroupTests
    {
        [TestMethod()]
        public void FindTopFrequentGroupTest()
        {
            var logs = new[]
            {
                "user1, pageA, Chrome, ...",
                "user2, pageE, Firefox, ...",
                "user1, pageB, Chrome, ...",
                "user2, pageB, Firefox, ...",
                "user2, pageC, Firefox, ...",
                "user1, pageC, Chrome, ...",
                "user2, pageD, Firefox, ...",
                "user1, pageD, Chrome, ...",
                "user1, pageE, Chrome, ...",
                "user2, pageA, Firefox, ..."

            };
            var sol = new FrequentKPagesGroup();

            var result = sol.FindTopFrequentGroup(logs, 3);

            ArrayHelper.PrintArray(result);
            Assert.AreEqual(3, result.Length);

        }
    }
}
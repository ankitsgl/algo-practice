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
    public class LRUCacheTests
    {
        [TestMethod()]
        public void CacheTest()
        {
            var cache = new LRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            var val = cache.Get(1);
            Assert.AreEqual(1, 1);
            cache.Put(3, 3);
            val = cache.Get(2);
            cache.Put(4, 4);
            val = cache.Get(1);
            Assert.AreEqual(-1, val);

            val = cache.Get(3);
            Assert.AreEqual(3, val);

            val = cache.Get(4);
            Assert.AreEqual(4, val);
        }
    }
}
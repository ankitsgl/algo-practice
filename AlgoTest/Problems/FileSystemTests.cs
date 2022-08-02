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
    public class FileSystemTests
    {
        [TestMethod()]
        public void FileSystemTest()
        {
            var sol = new FileSystem();
            var lsResult = sol.Ls("/");
            Assert.IsNotNull(lsResult);
            Assert.AreEqual(0, lsResult.Count);

            sol.Mkdir("/a/b/c");
            sol.AddContentToFile("/a/b/c/d", "hello");

            lsResult = sol.Ls("/");
            Assert.IsNotNull(lsResult);
            Assert.AreEqual(1, lsResult.Count);
            Assert.AreEqual("a", lsResult[0]);

            var text = sol.ReadContentFromFile("/a/b/c/d");
            Assert.AreEqual("hello", text);
        }

        [TestMethod()]
        public void FileSystemTest2()
        {
            var sol = new FileSystem();
            sol.Mkdir("/goowmfn");

            var lsResult = sol.Ls("/goowmfn");
            Assert.IsNotNull(lsResult);
            Assert.AreEqual(0, lsResult.Count);

            lsResult = sol.Ls("/");
            Assert.IsNotNull(lsResult);
            Assert.AreEqual(1, lsResult.Count);
            Assert.AreEqual("goowmfn", lsResult[0]);


            sol.Mkdir("/z");
            lsResult = sol.Ls("/");
            Assert.IsNotNull(lsResult);
            Assert.AreEqual(2, lsResult.Count);
            Assert.AreEqual("goowmfn", lsResult[0]);
            Assert.AreEqual("z", lsResult[1]);


            sol.AddContentToFile("/goowmfn/c", "shetopcy");

            lsResult = sol.Ls("/z");
            Assert.IsNotNull(lsResult);
            Assert.AreEqual(0, lsResult.Count);

            lsResult = sol.Ls("/goowmfn/c");
            Assert.IsNotNull(lsResult);
            Assert.AreEqual(1, lsResult.Count);
            Assert.AreEqual("c", lsResult[0]);


            lsResult = sol.Ls("/goowmfn");
            Assert.IsNotNull(lsResult);
            Assert.AreEqual(1, lsResult.Count);
            Assert.AreEqual("c", lsResult[0]);
        }
    }
}
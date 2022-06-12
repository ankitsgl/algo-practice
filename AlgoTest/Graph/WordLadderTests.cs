using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using algos.Helpers;

namespace algos.Graph.Tests;

[TestClass()]
public class WordLadderTests
{
    [TestMethod()]
    public void LadderLengthTest()
    {
        var algo = new WordLadder();

        var result = algo.LadderLength("lost", "miss", 
            new List<string> { "most", "mist", "miss", "lost", "fist", "fish" });
        Assert.AreEqual(4, result);
    }

    [TestMethod()]
    public void LadderLengthTest2()
    {
        var algo = new WordLadder();

        var result = algo.LadderLength("hit", "cog", new List<string> { "hot", "dot", "dog", "lot", "log", "cog" });
        Assert.AreEqual(5, result);
    }

    [TestMethod()]
    public void FindLadder_bfTest()
    {
        var algo = new WordLadder();

        var result = algo.FindLadders_bf("hit", "cog", new List<string> { "hot", "dot", "dog", "lot", "log", "cog" });

        ArrayHelper.PrintArray(result);

        Assert.AreEqual(2, result.Count);


        Assert.AreEqual(5, result[0].Count);
        Assert.AreEqual(5, result[1].Count);

    }

    [TestMethod()]
    public void FindLadder_opTest()
    {
        var algo = new WordLadder();

        var result = algo.FindLadders_op("hit", "cog", new List<string> { "hot", "dot", "dog", "lot", "log", "cog" });

        ArrayHelper.PrintArray(result);

        Assert.AreEqual(2, result.Count);


        Assert.AreEqual(5, result[0].Count);
        Assert.AreEqual(5, result[1].Count);

    }
}
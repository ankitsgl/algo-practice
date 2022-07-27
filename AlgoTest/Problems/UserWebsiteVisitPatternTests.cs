using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using algos.Helpers;

namespace algos.Problems.Tests;

[TestClass()]
public class UserWebsiteVisitPatternTests
{
    [TestMethod()]
    public void MostVisitedPatternTest()
    {
        var username = new[] { "joe", "joe", "joe", "james", "james", "james", "james", "mary", "mary", "mary" };
        var timestamp = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var website = new[] { "home", "about", "career", "home", "cart", "maps", "home", "home", "about", "career" };
        var sol = new UserWebsiteVisitPattern();
        var result = sol.MostVisitedPattern(username, timestamp, website);
        
        ArrayHelper.PrintArray(result);

        Assert.AreEqual(3, result.Count);

        Assert.IsTrue(result.Contains("home"));
        Assert.IsTrue(result.Contains("about"));
        Assert.IsTrue(result.Contains("career"));
    }
    [TestMethod()]
    public void MostVisitedPatternTest1()
    {
        var username = new[] { "dowg", "dowg", "dowg" };
        var timestamp = new[] { 158931262, 562600350, 148438945 };
        var website = new[] { "y", "loedo", "y" };
        var sol = new UserWebsiteVisitPattern();
        var result = sol.MostVisitedPattern(username, timestamp, website);

        ArrayHelper.PrintArray(result);

        Assert.AreEqual(3, result.Count);

        Assert.AreEqual("y", result[0]);
        Assert.AreEqual("y", result[1]);
        Assert.AreEqual("loedo", result[2]);
    }

    [TestMethod()]
    public void MostVisitedPatternTest2()
    {
        var username = new[] { "zkiikgv", "zkiikgv", "zkiikgv", "zkiikgv" };
        var timestamp = new[] { 43, 71, 38, 79};
        var website = new[] { "wnaaxbfhxp", "mryxsjc", "oz", "wlarkzzqht" };
        var sol = new UserWebsiteVisitPattern();
        var result = sol.MostVisitedPattern(username, timestamp, website);

        ArrayHelper.PrintArray(result);

        Assert.AreEqual(3, result.Count);
      
        Assert.AreEqual("oz", result[0]);
        Assert.AreEqual("mryxsjc", result[1]);
        Assert.AreEqual("wlarkzzqht", result[2]);
    }
}
namespace AlgoTest
{    
    using algos.Problems;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class TrappingRainWaterTests
    {
        [Ignore]
        [TestMethod]
        public void Test()
        {
            var data = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

            var algo = new TrappingRainWater();
            var result = algo.Calculate(data);
           // Assert.AreEqual(6, result);
        }

        
    }
}

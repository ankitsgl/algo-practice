namespace AlgoTest
{    
    using algos.Problems;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class ReverseStringTest
    {
        [TestMethod]
        public void Test()
        {
            var data = "Hello I am Ankit Singhals";
            var reverse = ReverseString.Reverse(data);
            
            Assert.AreEqual("slahgniS tiknA ma I olleH", reverse);            
        }

        [TestMethod]
        public void Test2()
        {
            var data = "HI";
            var reverse = ReverseString.Reverse(data);

            Assert.AreEqual("IH", reverse);
        }
    }
}

namespace AlgoTest
{    
    using algos.Problems;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class RotationalCipherTests
    {
        [TestMethod] 
        public void Test()
        {
            Console.WriteLine("" + (25%26));
            var rotate = RotationalCipher.rotationalCipher("Zebra-493", 3);

            Assert.AreEqual("Cheud-726", rotate);            
        }

         
    }
}

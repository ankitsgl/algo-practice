namespace AlgoTest
{    
    using algos.Problems;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class ValidateParenthesesTests
    {
        [TestMethod]
        public void Test()
        {
            var data = "ankit { sdf } fdf[ df] dfdfd( dfdf)";
            
            var result = ValidateParentheses.Validate(data);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test2()
        {
            var data = "ankit { s{ (  ) }df } fdf[[[ d]f]] dfdfd( dfdf)";

            var result = ValidateParentheses.Validate(data);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test3()
        {
            var data = "ankit { sdf } fdf[ df] dfdfd( dfdf";

            var result = ValidateParentheses.Validate(data);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test4()
        {
            var data = "{}";

            var result = ValidateParentheses.Validate(data);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test5()
        {
            var data = "{";

            var result = ValidateParentheses.Validate(data);
            Assert.IsFalse(result);
        }
    }
}

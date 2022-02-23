namespace AlgoTest
{    
    using algos.Problems;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class TaskSchedulerTests
    {
        [TestMethod]
        public void Test()
        {
            var data = new int[]{1,2,3,4 };

            var dependencies = new int[3][] ;
            dependencies[0] = new int[] {2,1};
            dependencies[1] = new int[] { 3, 2 };
            dependencies[2] = new int[] { 3, 1 };

            var result = TaskScheduler.IsValidOrder(data, dependencies);
            
            Assert.IsTrue(result);            
        }
        [TestMethod]
        public void Test2()
        {
            var data = new int[] { 1, 2, 3, 4 };

            var dependencies = new int[3][];
            dependencies[0] = new int[] { 2, 1 };
            dependencies[1] = new int[] { 3, 4 };
            dependencies[2] = new int[] { 3, 1 };

            var result = TaskScheduler.IsValidOrder(data, dependencies);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UsingDictionaryTest1()
        {
            var data = new int[] { 1, 2, 3, 4 };

            var dependencies = new int[3][];
            dependencies[0] = new int[] { 2, 1 };
            dependencies[1] = new int[] { 3, 2 };
            dependencies[2] = new int[] { 3, 1 };

            var result = TaskScheduler.IsValidOrderUsingDictionary(data, dependencies);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UsingDictionaryTest2()
        {
            var data = new int[] { 1, 2, 3, 4 };

            var dependencies = new int[3][];
            dependencies[0] = new int[] { 2, 1 };
            dependencies[1] = new int[] { 3, 4 };
            dependencies[2] = new int[] { 3, 1 };

            var result = TaskScheduler.IsValidOrderUsingDictionary(data, dependencies);

            Assert.IsFalse(result);
        }

    }
}

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
    public class JobSearchTests
    {
        [TestMethod()]
        public void JobSearchTest()
        {
            var algo = new JobSearch();
            algo.StoreDocument("oxayu project managers effectively deliver business results by championing a culture of accountability and consistent project management practices", 0);
            algo.StoreDocument("as the security software engineering manager at oxayu you are passionate about leveraging your software development and security domain knowledge to reduce our product security risks", 1);
            algo.StoreDocument("build and develop a high performance team of security software engineers", 2);
            algo.StoreDocument("deliver on oxayu security objectives via long term and quarterly objective and key results process", 3);
            algo.StoreDocument("own the performance management total rewards and career development of your team", 4);

            algo.PerformSearch("oxayu security");
            algo.PerformSearch("ankit");

        }
    }
}
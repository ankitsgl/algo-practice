using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Graph.Tests
{
    [TestClass()]
    public class FloodFillTests
    {
        [TestMethod()]
        public void FloodFillTest()
        {
            Console.WriteLine("Image: ");
            var input = new []{
                new[] { 1, 1, 1},
                new[] { 1, 1, 0},
                new[] { 1, 0, 0},                
            };

            Helpers.ArrayHelper.PrintArray(input);

            
            var sol = new FloodFillProblem();
            var res = sol.FloodFill(input, 0, 0, 2);
            Console.WriteLine("Result : ");
            Helpers.ArrayHelper.PrintArray(res);
            
        }

        [TestMethod()]
        public void FloodFill_DfsTest()
        {
            Console.WriteLine("Image: ");
            var input = new[]{
                new[] { 1, 1, 1},
                new[] { 1, 1, 0},
                new[] { 1, 0, 0},
            };

            Helpers.ArrayHelper.PrintArray(input);


            var sol = new FloodFillProblem();
            var res = sol.FloodFill_UsingDfs(input, 0, 0, 2);
            Console.WriteLine("Result : ");
            Helpers.ArrayHelper.PrintArray(res);

        }

        [TestMethod()]
        public void FloodFill_DfsTest2()
        {
            Console.WriteLine("Image: ");
            var input = new[]{
                new[] { 0,0,0},
                new[] { 0,1,1}                
            };

            Helpers.ArrayHelper.PrintArray(input);


            var sol = new FloodFillProblem();
            var res = sol.FloodFill_UsingDfs(input, 1, 1, 1);
            Console.WriteLine("Result : ");
            Helpers.ArrayHelper.PrintArray(res);
        }

        [TestMethod()]
        public void FloodFill_DfsTest3()
        {
            Console.WriteLine("Image: ");
            var input = new[]{
                new[] { 1,1,1},
                new[] { 1,1,0},
                new[] { 1,0,1}
            };

            Helpers.ArrayHelper.PrintArray(input);


            var sol = new FloodFillProblem();
            var res = sol.FloodFill_UsingDfs(input, 1, 1, 2);
            Console.WriteLine("Result : ");
            Helpers.ArrayHelper.PrintArray(res);
        }
    }
}
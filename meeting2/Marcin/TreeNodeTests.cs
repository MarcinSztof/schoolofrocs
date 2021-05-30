using HouseRobberIII;
using NUnit.Framework;
using System;
using System.Linq;

namespace HouseRobberTests
{
    public class TreeNodeTests
    {
        [Test]
        public void TreeTest1()
        {
            var tree = TreeNode.Create(new int?[]{3, 2, 3, null, 3, null, 1});
            var res = Solution.Rob(tree);
            Assert.AreEqual(7, res);
        }

        [Test]
        public void TreeTest2()
        {
            var tree = TreeNode.Create(new int?[]{3, 4, 5, 1, 3, null, 1});
            var res = Solution.Rob(tree);
            Assert.AreEqual(9, res);
        }

        [Test]
        public void DynTreeTest1()
        {
            var tree = new TreeNodeDyn(new int?[] { 3, 2, 3, null, 3, null, 1 }, 0);
            var res = Solution.Rob(tree);
            Assert.AreEqual(7, res);
        }

        [Test]
        public void DynTreeTest2()
        {
            var tree = new TreeNodeDyn(new int?[] { 3, 4, 5, 1, 3, null, 1 }, 0);
            var res = Solution.Rob(tree);
            Assert.AreEqual(9, res);
        }

        [Test]
        public void PerfTreeTest()
        {
            var rand = new Random();
            int?[] sample = Enumerable.Repeat((int?)rand.Next(1, 10000), 4095).Concat(Enumerable.Repeat((int?)null, 4096)).ToArray();
            var tree = TreeNode.Create(sample);
            var res = Solution.Rob(tree);
        }

        [Test]
        public void PerfDynTreeTest()
        {
            var rand = new Random();
            int?[] sample = Enumerable.Repeat((int?)rand.Next(1, 10000), 4095).Concat(Enumerable.Repeat((int?)null, 4096)).ToArray();
            var tree = new TreeNodeDyn(sample, 0);
            var res = Solution.Rob(tree);
        }

    }
}
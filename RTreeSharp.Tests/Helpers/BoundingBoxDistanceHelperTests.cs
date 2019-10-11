using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using RTreeSharp.Models;
using RTreeSharp.Helpers;

namespace RTreeSharp.Tests.Helpers
{
    public class BoundingBoxDistanceHelperTests
    {
        [Fact]
        public void FindFarthestBoundedPairTest()
        {
            var rootNode1 = new NodeValue(
                new BoundingBox(0, 0, 1, 1), "r");
            var closeNode1 = new NodeValue(
                new BoundingBox(3, 3, 1, 1), "c");
            var farNode1 = new NodeValue(
                new BoundingBox(100, 100, 1, 1), "f");

            var closePair = BoundingBoxDistanceHelper.FindFarthestBoundedPair(
                new List<IBounded>() { rootNode1, closeNode1, farNode1 });

            var closePairList = new List<IBounded>() { closePair.Item1, closePair.Item2 };
            Assert.Contains(rootNode1, closePairList);
            Assert.Contains(farNode1, closePairList);
        }
    }
}

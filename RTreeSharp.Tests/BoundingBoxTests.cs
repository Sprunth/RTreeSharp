using Xunit;
using RTreeSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTreeSharp.Tests
{
    public class BoundingBoxTests
    {
        [Fact()]
        public void EnlargedBoundingBoxTest()
        {
            var baseBounds = new BoundingBox(0, 0, 10, 10);
            var newBounds = new BoundingBox(10, 10, 5, 15);

            var enlargedBounds = BoundingBox.EnlargedBoundingBox(baseBounds, newBounds);
            Assert.Equal(0, enlargedBounds.Left);
            Assert.Equal(0, enlargedBounds.Top);
            Assert.Equal(15, enlargedBounds.Right);
            Assert.Equal(25, enlargedBounds.Bottom);
        }

        [Fact()]
        public void AreaTest()
        {
            var baseBounds = new BoundingBox(5, 5, 10, 20);
            Assert.Equal(baseBounds.Area, 10 * 20);
        }
    }
}
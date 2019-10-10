using RTreeSharp.Models;
using System;

namespace RTreeSharp
{
    public class RTree
    {
        // todo: Rtree should really just be an internal node
        // only reason it is not is for public/private methods/classes
        private InternalNode rootNode;
        public void Insert(BoundingBox objBounds, String obj)
        {
            if (rootNode is null)
            {
                rootNode = new InternalNode(null, objBounds);
            }

            var inserted = rootNode.Insert(objBounds, obj);
            if (!inserted)
            {
                InternalNode.SplitNode(rootNode);
            }
        }
    }
}

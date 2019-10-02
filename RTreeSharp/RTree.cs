using RTreeSharp.Models;
using System;

namespace RTreeSharp
{
    public class RTree
    {
        private InternalNode rootNode;
        public void Insert(BoundingBox objBounds, String obj)
        {
            if (rootNode is null)
            {
                rootNode = new InternalNode(null, objBounds);
            }

            rootNode.Insert(objBounds, obj);
        }
    }
}

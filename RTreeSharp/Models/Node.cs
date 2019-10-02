using System;
using System.Collections.Generic;
using System.Text;

namespace RTreeSharp.Models
{
    abstract class Node
    {
        public BoundingBox boundingBox;
        protected Node parent;
        public Node(Node parent)
        {
            this.parent = parent;
        }
        public abstract bool Insert(BoundingBox objBounds, String obj);
        public abstract void SplitChild(Node child);
    }
}

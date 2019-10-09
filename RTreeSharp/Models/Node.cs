using System;
using System.Collections.Generic;
using System.Text;

namespace RTreeSharp.Models
{
    abstract class Node
    {
        public BoundingBox boundingBox;
        protected Node parent;
        protected List<Node> children = new List<Node>();
        protected List<Tuple<BoundingBox, string>> values = new List<Tuple<BoundingBox, string>>();
        protected bool IsLeafNode => children.Count == 0;
        public Node(Node parent, BoundingBox boundingBox)
        {
            this.parent = parent;
            this.boundingBox = boundingBox;
        }
        public abstract bool Insert(BoundingBox objBounds, String obj);
        public abstract void SplitChild(Node child);
    }
}

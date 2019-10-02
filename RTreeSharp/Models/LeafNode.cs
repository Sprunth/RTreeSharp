using System;
using System.Collections.Generic;
using System.Text;

namespace RTreeSharp.Models
{
    class LeafNode : Node
    {
        static int LEAF_CAPACITY = 3;

        //todo: change String to generic
        public List<KeyValuePair<BoundingBox, String>> Values { get; private set; } = new List<KeyValuePair<BoundingBox, string>>();
        private InternalNode parent;
        public LeafNode(InternalNode parent) : base(parent) { }

        public override bool Insert(BoundingBox objBounds, string obj)
        {
            if (Values.Count > LEAF_CAPACITY) { return false; }

            Values.Add(new KeyValuePair<BoundingBox, string>(objBounds, obj));
            return true;
        }

        public override void SplitChild(Node child)
        {
            throw new NotImplementedException();
        }
    }
}

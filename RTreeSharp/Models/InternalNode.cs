using System;
using System.Collections.Generic;
using System.Text;

namespace RTreeSharp.Models
{
    class InternalNode : Node
    {
        private List<Node> children = new List<Node>();
        private InternalNode parent;
        public InternalNode(InternalNode parent) : base(parent) { }

        public override bool Insert(BoundingBox objBounds, string obj)
        {
            foreach (var child in children)
            {
                if (child.boundingBox.Contains(objBounds))
                {
                    var inserted = child.Insert(objBounds, obj);
                    if (!inserted)
                    {
                        
                    }
                    return true;
                }
            }

            // if we reach here, no child can contain this obj w/o enlargement of bb

            // todo: enlargement algorithm...
            throw new NotImplementedException();
        }

        public override void SplitChild(Node child)
        {
            throw new NotImplementedException();
        }
    }
}

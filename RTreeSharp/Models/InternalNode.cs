using System;
using System.Collections.Generic;
using System.Text;

namespace RTreeSharp.Models
{
    class InternalNode : Node
    {
        public static int NODE_CAPACITY = 3;
        public InternalNode(InternalNode parent, BoundingBox boundingBox) : base(parent, boundingBox) 
        {
        }

        public override bool Insert(BoundingBox objBounds, string obj)
        {
            if (IsLeafNode)
            {
                if (values.Count < NODE_CAPACITY)
                {
                    values.Add(obj);
                    return true;
                }
                // need to split
                return false;
            }

            foreach (var child in children)
            {
                if (child.boundingBox.Contains(objBounds))
                {
                    var inserted = child.Insert(objBounds, obj);
                    if (!inserted)
                    {
                        SplitChild(child);

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

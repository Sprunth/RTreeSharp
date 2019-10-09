using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
                // Note that we add the new element regardless of whether we need to split
                values.Add(new Tuple<BoundingBox, string>(objBounds, obj));
                var needToSplit = values.Count >= NODE_CAPACITY;
                return needToSplit;
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

        private Node SelectChildForEnglargement(BoundingBox boundsToContain)
        {
            return children.OrderBy((node) => BoundingBox.EnlargedBoundingBox(node.boundingBox, boundsToContain).Area).First();
        }
    }
}

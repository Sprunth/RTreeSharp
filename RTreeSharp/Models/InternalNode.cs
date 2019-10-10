using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RTreeSharp.Models
{
    class InternalNode : Node
    {
        public static int NODE_CAPACITY = 3;
        public static void SplitNode(Node node)
        {
            var splitPair = (node as InternalNode).FindFarthestValuePair();

            throw new NotImplementedException();
        }

        public InternalNode(InternalNode parent, BoundingBox boundingBox) : base(parent, boundingBox) 
        {
        }

        public override bool Insert(BoundingBox objBounds, string obj)
        {
            if (IsLeafNode)
            {
                // Note that we add the new element regardless of whether we need to split
                values.Add(new NodeValue(objBounds, obj));
                var needToSplit = values.Count >= NODE_CAPACITY;
                return !needToSplit;
            }

            foreach (var child in children)
            {
                if (child.boundingBox.Contains(objBounds))
                {
                    var inserted = child.Insert(objBounds, obj);
                    if (!inserted)
                    {
                        SplitNode(child);

                    }
                    return true;
                }
            }

            // if we reach here, no child can contain this obj w/o enlargement of bb

            // todo: enlargement algorithm...
            throw new NotImplementedException();
        }

        private Node SelectChildForEnglargement(BoundingBox boundsToContain)
        {
            return children.OrderBy((node) => BoundingBox.EnlargedBoundingBox(node.boundingBox, boundsToContain).Area).First();
        }

        private Tuple<Node, Node> FindFarthestChildrenPair()
        {
            var permutations = children.SelectMany(c => children.Select(c2 => new { c, c2 })).ToList();

            throw new NotImplementedException();
        }

        private Tuple<NodeValue, NodeValue> FindFarthestValuePair()
        {
            var permutations = values.SelectMany(c => children.Select(c2 => new { c, c2 })).ToList();
            throw new NotImplementedException();
        }
    }
}

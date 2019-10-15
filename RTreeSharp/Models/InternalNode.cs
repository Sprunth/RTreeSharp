using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RTreeSharp.Helpers;

namespace RTreeSharp.Models
{
    class InternalNode : Node
    {
        public static int NODE_CAPACITY = 3;
        public static void SplitNode(Node node)
        {
            var internalNode = node as InternalNode;
            var splitPair = BoundingBoxDistanceHelper.FindFarthestBoundedPair(internalNode.children);

            var l1 = new InternalNode(node.parent, node.BoundingBox);
            l1.children.Add(splitPair.Item1 as Node);
            var l2 = new InternalNode(node.parent, node.BoundingBox);
            l2.children.Add(splitPair.Item2 as Node);

            var remaining = internalNode.children.Where((it) => !it.Equals(splitPair.Item1) && !it.Equals(splitPair.Item2));
            foreach(var n in remaining)
            {
                // get child with minimum enlargement
                var l1Enlargement = n.EnlargementRequired(l1.BoundingBox);
                var l2Enlargement = n.EnlargementRequired(l2.BoundingBox);

                // if tie, assign to list with smaller bounding area

                // if tie, assign to smaller list
            }            

            throw new NotImplementedException();
        }

        private static IEnumerable<IBounded> SortByRequiredEnlargement(IEnumerable<IBounded> bounds, BoundingBox boundsToContain)
        {
            return bounds.OrderBy((node) => BoundingBox.EnlargedBoundingBox(node.BoundingBox, boundsToContain).Area);
        }

        public InternalNode(Node parent, BoundingBox boundingBox) : base(parent, boundingBox) 
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
                if (child.BoundingBox.Contains(objBounds))
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
    }
}

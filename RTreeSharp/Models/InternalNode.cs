using System;
using System.Collections.Generic;
using System.Text;

namespace RTreeSharp.Models
{
    class InternalNode : Node
    {
        private List<Node> children = new List<Node>();
        public void Insert(BoundingBox objBounds, String obj, Node n)
        {

        }
    }
}

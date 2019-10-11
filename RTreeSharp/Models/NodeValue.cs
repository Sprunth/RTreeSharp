using System;
using System.Collections.Generic;
using System.Text;

namespace RTreeSharp.Models
{
    public class NodeValue : IBounded
    {
        public String Value { get; set; }
        public BoundingBox BoundingBox { get; set; }

        public NodeValue(BoundingBox bounds, String value)
        {
            BoundingBox = bounds;
            Value = value;
        }
    }
}

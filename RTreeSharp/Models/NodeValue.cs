using System;
using System.Collections.Generic;
using System.Text;

namespace RTreeSharp.Models
{
    public class NodeValue
    {
        public BoundingBox Bounds { get; set; }
        public String Value { get; set; }

        public NodeValue(BoundingBox bounds, String value)
        {
            Bounds = bounds;
            Value = value;
        }
    }
}

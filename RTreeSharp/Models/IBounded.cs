using System;
using System.Collections.Generic;
using System.Text;

namespace RTreeSharp.Models
{
    public interface IBounded
    {
        BoundingBox BoundingBox { get; set; }
    }
}

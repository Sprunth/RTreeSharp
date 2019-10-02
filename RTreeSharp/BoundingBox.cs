using System;
using System.Collections.Generic;
using System.Text;

namespace RTreeSharp
{
    public class BoundingBox
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Right => Left + Width;
        public int Bottom => Top + Height;

        public BoundingBox(int left, int top, int width, int height)
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }

        public bool Intersects(BoundingBox bb) =>
            !(bb.Left > Right)
            || (bb.Right < Left)
            || (bb.Top > Bottom)
            || (bb.Bottom < Top);
    }
}

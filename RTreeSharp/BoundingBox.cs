using System;
using System.Collections.Generic;
using System.Text;

namespace RTreeSharp
{
    public class BoundingBox
    {
        // todo: support floating point dimensions
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Right => Left + Width;
        public int Bottom => Top + Height;

        public BoundingBox(int left, int top, int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("width and height have to be positive");
            }

            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }

        public bool Intersects(BoundingBox bb) =>
            !(bb.Left >= Right)
            || (bb.Right <= Left)
            || (bb.Top >= Bottom)
            || (bb.Bottom <= Top);

        public bool Contains(BoundingBox bb) =>
            bb.Left >= Left
            && bb.Right <= Right
            && bb.Top >= Top
            && bb.Bottom <= Bottom;

        public int Area => Width * Height;
        public Tuple<float, float> Center => new Tuple<float, float>(Left + (Width / 2f), Top + (Height / 2f));

        public static BoundingBox EnlargedBoundingBox(BoundingBox currentBounds, BoundingBox newEntry)
        {
            if (currentBounds == null)
                throw new ArgumentNullException(nameof(currentBounds));
            if (newEntry == null)
                throw new ArgumentNullException(nameof(newEntry));

            var left = Math.Min(currentBounds.Left, newEntry.Left);
            var right = Math.Max(currentBounds.Right, newEntry.Right);
            var top = Math.Min(currentBounds.Top, newEntry.Top);
            var bottom = Math.Max(currentBounds.Bottom, newEntry.Bottom);
            return new BoundingBox(left, top, right - left, bottom - top);
        }
    }
}

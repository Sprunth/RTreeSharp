using RTreeSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTreeSharp.Helpers
{
    public static class BoundingBoxDistanceHelper
    { 
        public static Tuple<IBounded, IBounded> FindFarthestBoundedPair(IEnumerable<IBounded> boundedObjects)
        {
            var objects = boundedObjects.ToList();
            Tuple<IBounded, IBounded> bestPair = null;
            var largestDist = float.MinValue;
            for (var i = 0; i < objects.Count; i++)
            {
                for (var j = i + 1; j < objects.Count; j++)
                {
                    // todo: vector class?
                    var center1 = objects[i].BoundingBox.Center;
                    var center2 = objects[j].BoundingBox.Center;
                    var dist = (float)Math.Sqrt(Math.Pow(center2.Item1 - center1.Item1, 2) + Math.Pow(center2.Item2 - center1.Item2, 2));
                    if (dist > largestDist)
                    {
                        largestDist = dist;
                        bestPair = new Tuple<IBounded, IBounded>(objects[i], objects[j]);
                    }
                }
            }
            return bestPair;
        }
    }
}

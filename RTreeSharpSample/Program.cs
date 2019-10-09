using System;
using RTreeSharp;

namespace RTreeSharpSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new RTree();
            tree.Insert(new BoundingBox(20, 3, 5, 10), "value1");
            tree.Insert(new BoundingBox(30, 32, 5, 15), "value2");
            tree.Insert(new BoundingBox(40, 1, 25, 10), "value3");
            tree.Insert(new BoundingBox(40, 1, 25, 12), "value5");
            Console.WriteLine("Hello World!");
        }
    }
}

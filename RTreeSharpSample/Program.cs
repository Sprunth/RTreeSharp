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
            Console.WriteLine("Hello World!");
        }
    }
}

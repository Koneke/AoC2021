using System;
using System.IO;
using System.Linq;

var depths = File.ReadLines("part-1.txt")
    .Select(l => Convert.ToInt32(l))
    .ToList();

var elements = 3;
var windows = 
    Enumerable.Range(elements - 1, depths.Count() + 1 - elements)
        .Select(i => Enumerable.Range(i + 1 - elements, elements)
            .Select(j => depths[j]).Sum());

Console.WriteLine(
    windows
        .Skip(1)
        .Zip(windows, (current, last) => (current, last))
        .Where(lc => lc.current > lc.last)
        .Count());

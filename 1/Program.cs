using System;
using System.IO;
using System.Linq;

var depths = File.ReadLines("input.txt")
    .Select(l => Convert.ToInt32(l))
    .ToList();

int solve(int windowSize)
{
    var windows = 
        Enumerable.Range(windowSize - 1, depths.Count() + 1 - windowSize)
            .Select(i => Enumerable.Range(i + 1 - windowSize, windowSize)
                .Select(j => depths[j]).Sum());

    return windows
        .Skip(1)
        .Zip(windows, (current, last) => (current, last))
        .Where(lc => lc.current > lc.last)
        .Count();
}

Console.WriteLine($"Part 1: {solve(1)}");
Console.WriteLine($"Part 2: {solve(3)}");


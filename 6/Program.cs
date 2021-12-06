using System.Collections.Generic;
using System.Linq;

Dictionary<int, ulong> Step(Dictionary<int, ulong> current) =>
    Enumerable.Range(0, 9).ToDictionary(
        x => x,
        x => current[(x + 1) % 9] + (x == 6 ? current[0] : 0));

var current = Enumerable.Range(0, 9).ToDictionary(x => x, x => (ulong) 0);
File.ReadLines("input.txt")
    .First()
    .Split(",")
    .Select(x => Convert.ToInt32(x))
    .Select(x => current[x] += 1)
    .ToList();

for (var i = 0; i <= 256; i++)
    current = Step(current);

Console.WriteLine(
    Enumerable
        .Range(0, 8)
        .Select(x => current[x])
        .Aggregate((ulong) 0, (c, n) => c + n));

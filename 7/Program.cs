// Today, I choose violence
// Not because I must
// But because I can
// - Albert Einstein (probably)

using System.Linq;

var input = System.IO.File.ReadAllLines("input.txt")
    .First()
    .Split(',')
    .Select(x => Convert.ToInt32(x))
    .OrderBy(x => x);

Console.WriteLine(
    string.Join(
        ", ", 
        (new [] { true, false })
            .Select(part1 =>
            part1
                ? input
                    .Select(x => Math.Abs(
                        (input.Count() % 2 == 1
                            ? input.ElementAt(input.Count() / 2)
                            : (input.ElementAt((input.Count() - 1) / 2)
                                + input.ElementAt(input.Count() / 2))
                                / 2)
                        - x
                        ))
                    .Sum()
                : Enumerable
                    .Range(input.Min(), input.Max() - input.Min())
                    .Select(x => 
                        input
                            .Select(y => Enumerable.Range(1, Math.Abs(x - y)).Sum())
                            .Sum())
                    .OrderBy(x => x)
                    .First())));


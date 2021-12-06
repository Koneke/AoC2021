var input = File.ReadAllLines("input.txt");

var marks = 
    input.First().Split(",")
    .Select(x => Convert.ToInt32(x));

var boards =
    string.Join("\n", input.Skip(2))
    .Split(
        new string[] { "\n\n" },
        StringSplitOptions.RemoveEmptyEntries)
    .Select(board =>
        board.Split(
            new char[] { '\n', ' ' },
            StringSplitOptions.RemoveEmptyEntries))
    .Select(board =>
        board.Select(cell => Convert.ToInt32(cell)));

IEnumerable<int> QueryBoard(IEnumerable<int> board, int index, bool row) =>
    Enumerable
        .Range(0, 5)
        .Select(x => row ? index * 5 + x : index + x * 5)
        .Select(x => board.ElementAt(x));

bool Won(IEnumerable<int> board, IEnumerable<int> marked) =>
    Enumerable
        .Range(0, 5)
        .Any(x =>
            QueryBoard(board, x, true)
                .All(y => marked.Contains(y)) ||
            QueryBoard(board, x, false)
                .All(y => marked.Contains(y)));

var marked = new List<int>();
foreach (var mark in marks)
{
    marked.Add(mark);

    var winner = boards.FirstOrDefault(board => Won(board, marked));
    if (winner != null)
    {
        Console.WriteLine("Part 1");
        Console.WriteLine(
            winner.Where(x => !marked.Contains(x)).Sum()
            * mark);
        break;
    }
}

marked.Clear();
for (var i = 0; i < marks.Count(); i++)
{
    marked.Add(marks.ElementAt(i));

    var losers = boards.Where(board => !Won(board, marked));
    if (losers.Count() == 1)
    {
        var loser = losers.First();
        int mark = marks.ElementAt(i);
        while (!Won(loser, marked))
        {
            mark = marks.ElementAt(++i);
            marked.Add(mark);
        }

        Console.WriteLine("Part 2");
        Console.WriteLine(
            loser.Where(x => !marked.Contains(x)).Sum()
            * mark);
        break;
    }
}

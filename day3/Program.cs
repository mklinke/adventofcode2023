Console.WriteLine("Day 3");

var allLines = new LinkedList<string>(File.ReadAllLines("input.txt"));

var stars = new Dictionary<Tuple<int, int>, List<int>>();
var lineIndex = 0;
for (var node = allLines.First; node != null; node = node.Next, lineIndex++)
{
    var previousNode = node.Previous;
    var nextNode = node.Next;
    for (var i = 0; i < node.Value.Length; i++)
    {
        var character = node.Value[i];
        var currentNumberString = "";
        var startIndex = i;
        while (character >= 48 && character <= 57)
        {
            currentNumberString += character;
            if (i == node.Value.Length - 1) { break; }
            character = node.Value[++i];
        }
        if (currentNumberString.Length > 0)
        {
            var currentNumber = int.Parse(currentNumberString);
            var endIndex = startIndex + currentNumberString.Length - 1;
            for (var checkIndex = Math.Max(0, startIndex - 1); checkIndex < Math.Min(endIndex + 2, node.Value.Length); checkIndex++)
            {
                if (previousNode != null && previousNode.Value[checkIndex] == '*')
                {
                    var coordinates = new Tuple<int, int>(lineIndex - 1, checkIndex);
                    AddAdjacentNumber(stars, currentNumber, coordinates);
                }
                if (nextNode != null && nextNode.Value[checkIndex] == '*')
                {
                    var coordinates = new Tuple<int, int>(lineIndex + 1, checkIndex);
                    AddAdjacentNumber(stars, currentNumber, coordinates);
                }
            }

            if (startIndex > 0)
            {
                if (node.Value[startIndex - 1] == '*')
                {
                    var coordinates = new Tuple<int, int>(lineIndex, startIndex - 1);
                    AddAdjacentNumber(stars, currentNumber, coordinates);
                }
            }

            if (endIndex < node.Value.Length - 1)
            {
                if (node.Value[endIndex + 1] == '*')
                {
                    var coordinates = new Tuple<int, int>(lineIndex, endIndex + 1);
                    AddAdjacentNumber(stars, currentNumber, coordinates);
                }
            }
        }
    }
}

var sum = 0;

foreach (var star in stars.Where((entry) => entry.Value.Count == 2))
{
    sum += star.Value.Aggregate((a, b) => a * b);
}

Console.WriteLine("Sum: " + sum);

static void AddAdjacentNumber(Dictionary<Tuple<int, int>, List<int>> stars, int currentNumber, Tuple<int, int> coordinates)
{
    if (stars.TryGetValue(coordinates, out var adjacentNumbers))
    {
        adjacentNumbers.Add(currentNumber);
    }
    else
    {
        stars.Add(coordinates, new List<int> { currentNumber });
    }
}
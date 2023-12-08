Console.WriteLine("Day 2");

var allLines = File.ReadAllLines("input.txt");

var target = new Dictionary<string, int> { { "red", 12 }, { "green", 13 }, { "blue", 14 } };

var sum = 0;
foreach (var line in allLines)
{
    var parts = line.Split(":");
    var gameId = int.Parse(parts[0].Substring(5));
    var sets = parts[1].Split(";");
    var possible = true;
    foreach (var set in sets)
    {
        var cubes = set.Split(",");
        foreach (var cube in cubes)
        {
            var cubeParts = cube.Trim().Split(" ");
            var number = int.Parse(cubeParts[0]);
            var color = cubeParts[1];
            if (!target.ContainsKey(color) || number > target[color])
            {
                possible = false;
                break;
            }
        }
        if (!possible)
        {
            break;
        }
    }
    if (possible)
    {
        sum += gameId;
    }
}

Console.WriteLine("Sum: " + sum);
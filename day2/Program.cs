Console.WriteLine("Day 2");

var allLines = File.ReadAllLines("input.txt");

var sum = 0;
foreach (var line in allLines)
{
    var parts = line.Split(":");
    var gameId = int.Parse(parts[0].Substring(5));
    var sets = parts[1].Split(";");
    var minimumCubes = new Dictionary<string, int>();
    foreach (var set in sets)
    {
        var cubes = set.Split(",");
        foreach (var cube in cubes)
        {
            var cubeParts = cube.Trim().Split(" ");
            var number = int.Parse(cubeParts[0]);
            var color = cubeParts[1];
            if (!minimumCubes.ContainsKey(color) || number > minimumCubes[color])
            {
                minimumCubes[color] = number;
            }
        }
    }
    sum += minimumCubes.Values.Aggregate((a, b) => a * b);
}

Console.WriteLine("Sum: " + sum);
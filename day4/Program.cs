Console.WriteLine("Day 4");

var allLines = File.ReadAllLines("input.txt");

var sum = 0;
foreach (var line in allLines)
{
    var numberGroups = line.Split(":")[1].Trim().Split("|");
    var winningNumbers = numberGroups[0].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(text => int.Parse(text)).ToList();
    var ownNumbers = numberGroups[1].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(text => int.Parse(text)).ToList();
    var hits = 0;
    foreach (var winningNumber in winningNumbers)
    {
        if (ownNumbers.Contains(winningNumber))
        {
            hits += 1;
        }
    }
    if (hits > 0)
    {
        var value = 1;
        for (var i = 0; i < hits - 1; i++) {
            value *= 2;
        }
        sum += value;
    }
}

Console.WriteLine("Sum: " + sum);
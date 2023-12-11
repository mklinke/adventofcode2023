Console.WriteLine("Day 4");

var allLines = File.ReadAllLines("input.txt");

var cardCopies = new Dictionary<int, int>();
var sum = 0;
foreach (var line in allLines)
{
    var currentCard = int.Parse(line.Split(":")[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);
    var numberGroups = line.Split(":")[1].Trim().Split("|");
    var winningNumbers = numberGroups[0].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(text => int.Parse(text)).ToList();
    var ownNumbers = numberGroups[1].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(text => int.Parse(text)).ToList();
    var cardInstances = 1;
    if (cardCopies.TryGetValue(currentCard, out var copies))
    {
        cardInstances += copies;
    }
    var hits = 0;
    foreach (var winningNumber in winningNumbers)
    {
        if (ownNumbers.Contains(winningNumber))
        {
            hits++;
            if (!cardCopies.ContainsKey(currentCard + hits))
            {
                cardCopies[currentCard + hits] = cardInstances;
            }
            else
            {
                cardCopies[currentCard + hits] += cardInstances;
            }
        }
    }
    sum += cardInstances;
}

Console.WriteLine("Sum: " + sum);
Console.WriteLine("Day 3");

var allLines = new LinkedList<string>(File.ReadAllLines("input.txt"));

var sum = 0;
for (var node = allLines.First; node != null; node = node.Next)
{
    var previousNode = node.Previous;
    var nextNode = node.Next;
    var numbers = new List<int>();
    for (var i = 0; i < node.Value.Length; i++)
    {
        var character = node.Value[i];
        var currentNumber = "";
        var startIndex = i;
        while (character >= 48 && character <= 57)
        {
            currentNumber += character;
            if (i == node.Value.Length - 1) { break; }
            character = node.Value[++i];
        }

        if (currentNumber.Length > 0)
        {
            var endIndex = startIndex + currentNumber.Length - 1;
            var adjacentToSpecialChar = false;
            for (var checkIndex = Math.Max(0, startIndex - 1); checkIndex < Math.Min(endIndex + 2, node.Value.Length); checkIndex++)
            {
                if (previousNode != null && previousNode.Value[checkIndex] != '.' && (previousNode.Value[checkIndex] < 48 || previousNode.Value[checkIndex] > 57))
                {
                    adjacentToSpecialChar = true;
                }
                if (nextNode != null && nextNode.Value[checkIndex] != '.' && (nextNode.Value[checkIndex] < 48 || nextNode.Value[checkIndex] > 57))
                {
                    adjacentToSpecialChar = true;
                }
                if (adjacentToSpecialChar)
                {
                    break;
                }
            }

            if (startIndex > 0)
            {
                if (node.Value[startIndex - 1] != '.' && (node.Value[startIndex - 1] < 48 || node.Value[startIndex - 1] > 57))
                {
                    adjacentToSpecialChar = true;
                }
            }

            if (endIndex < node.Value.Length - 1)
            {
                
                if (node.Value[endIndex + 1] != '.' && (node.Value[endIndex + 1] < 48 || node.Value[endIndex + 1] > 57))
                {
                    adjacentToSpecialChar = true;
                }
            }
            if (adjacentToSpecialChar)
            {
                sum += int.Parse(currentNumber);
            }
            currentNumber = "";
        }
    }
}

Console.WriteLine("Sum: " + sum);
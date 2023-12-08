Console.WriteLine("Day 1");

var numbers = new[] {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

var allLines = File.ReadAllLines("input.txt");

var sum = 0;

foreach (var line in allLines)
{
    var characterIndex = 0;
    var digits = new List<int>();
    foreach (var character in line)
    {
        if (character >= 48 && character <= 57) {
            digits.Add(((int)character)-48);
        }
        var numberIndex = 0;
        foreach(var number in numbers)
        {
            numberIndex++;
            if (line[characterIndex..].StartsWith(number)) 
            {
                digits.Add(numberIndex);
            }
        }
        characterIndex++;
    }

    var calibrationValue = digits.First() + "" + digits.Last();
    sum += int.Parse(calibrationValue);
}

Console.WriteLine("Sum: "+sum);
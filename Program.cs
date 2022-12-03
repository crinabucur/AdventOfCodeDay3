internal class Program
{
    public static void Main()
    {
        const bool firstProblem = false;
        
        long sumOfPriorities = 0;
        var rucksackNumber = 0;
        var rucksacks = new string[3];
        
        foreach (var rucksackContent in File.ReadLines(@"C:\Users\CrinaBucur\input.txt"))
        {
            if (firstProblem)
            {
                var compartment1Contents = rucksackContent[..(rucksackContent.Length / 2)];
                var compartment2Contents = rucksackContent.Substring(rucksackContent.Length / 2, rucksackContent.Length / 2);

                sumOfPriorities += GetItemPriority(compartment1Contents.First(item => compartment2Contents.Contains(item)));
            }
            else
            {
                rucksacks[rucksackNumber % 3] = rucksackContent;
                if (rucksackNumber % 3 == 2)
                {
                    sumOfPriorities += GetItemPriority(rucksacks[0].First(item => rucksacks[1].Contains(item) && rucksacks[2].Contains(item)));
                }
                rucksackNumber++;
            }
        }
        
        const string resultTemplate = firstProblem
            ? "The sum of priorities for common items across both compartments is {0} "
            : "The sum of badges' priorities is {0} ";
        
        Console.WriteLine(resultTemplate, sumOfPriorities); 
        Console.ReadLine();  
    }

    private static int GetItemPriority(char item)
    {
        // a = 97 =>  1; z = 122 => 26 (-96)
        // A = 65 => 27; Z = 90  => 52 (-38)
        var value = (int)item;
        return value > 90 ? value - 96 : value - 38;
    }
}
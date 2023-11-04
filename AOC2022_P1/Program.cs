using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AOC2022_P1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\buzz5\OneDrive\Desktop\AOC2022\p1.txt";
            List<int> calories = new List<int>(); // This will hold the total calories for each elf after each blank line

            try
            {
                // Read all lines from the file
                List<string> lines = File.ReadAllLines(filePath).ToList();

                int currentCalorie = 0; // This will accumulate the sum of calories for each elf between blank lines

                foreach (string line in lines)
                {
                    // Check if the line is blank
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        // If the line is blank, add the current sum to the list and reset currentCalorie
                        calories.Add(currentCalorie);
                        currentCalorie = 0;
                    }
                    else if (int.TryParse(line, out int number))
                    {
                        // Add the number to the current calorie total
                        currentCalorie += number;
                    }
                    else
                    {
                        Console.WriteLine($"Could not parse '{line}' as an integer.");
                    }
                }

                // Add the last sum if the file does not end with a blank line
                calories.Add(currentCalorie);

                // Print the elf's calorie totals to confirm
                Console.WriteLine("Sums of Calories for each Elf:");
                foreach (int caloire in calories)
                {
                    Console.WriteLine(caloire);
                }

                //Part 2 Answer:
                var orderedCalories = calories.OrderByDescending(n => n).ToList();
                if (orderedCalories.Count >= 3) 
                {
                    int totalOfTopThree = orderedCalories[0] + orderedCalories[1] + orderedCalories[2];
                    Console.WriteLine($"1st: {orderedCalories[0]}");
                    Console.WriteLine($"2nd: {orderedCalories[1]}");
                    Console.WriteLine($"3rd: {orderedCalories[2]}");
                    Console.WriteLine($"Total: {totalOfTopThree}");
                }
                else
                {
                    // Handle the situation where there are less than 3 items
                    Console.WriteLine("There are less than 3 calorie counts available.");
                }

                // Part 1 Answer:
                int maxCalories = calories.Max();
                Console.WriteLine($"The Elf with most caloires has: {maxCalories}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;

namespace AOC2022_P3
{
    public class Program
    {
        // Splits a word into two halves and returns them as a tuple : Part 1
        /*public static (string, string) SplitWordInHalf(string word)
        {
            int middle = word.Length / 2;
            string firstHalf = word.Substring(0, middle);
            string secondHalf = word.Substring(middle);
            return (firstHalf, secondHalf);
        }*/

        // Finds and returns matching letters between two strings
        /*public static string FindMatchingLetters(string firstHalf, string secondHalf) : Part 1
        {
            string matchingLetters = "";

            // Iterate over each character in the first half
            foreach (char c in firstHalf)
            {
                // If the second half contains the character, add it to the result
                if (secondHalf.Contains(c))
                {
                    matchingLetters += c;
                }
            }
            return matchingLetters;
        }*/

        // Calculates the total value of matching letters between two halves
        /*public static int CalculateTotalValueOfMatches(string firstHalf, string secondHalf) : Part 1
        {
            int sum = 0;
            HashSet<char> matches = new HashSet<char>();

            // Iterate over each character in the first half
            foreach (char c in firstHalf)
            {
                // Check for matches that haven't been counted yet
                if (secondHalf.Contains(c) && !matches.Contains(c))
                {
                    // Add the character to the set and increment sum by its value
                    matches.Add(c);
                    sum += GetValueOfLetter(c);
                }
            }
            return sum;
        }*/

        // Assigns a value to a letter based on its position in the alphabet and case
        public static int GetValueOfLetter(char letter)
        {
            // Calculate the value for lowercase letters
            if (char.IsLower(letter))
            {
                return letter - 'a' + 1;
            }
            // Calculate the value for uppercase letters
            else if (char.IsUpper(letter))
            {
                return letter - 'A' + 27;
            }
            // Return 0 if it's not a letter (or could throw an exception)
            return 0;
        }

        // This method finds common letters between three strings
        public static string FindCommonLetters(string first, string second, string third)
        {
            var common = first.Intersect(second).Intersect(third);
            return new string(common.ToArray());
        }



        // End of Functions
        static void Main(string[] args)
        {
            // Rucksack = 2 large componenets
            /* All items of a given type are meant to go into one of the two componenets
             * The elf failed to do this for one item per rucksack
             * Each item is identified to by a single lower case and upper case letter
             * For example rucksack:Compartment 1: vJrwpWtwJgWr Compartment 2: hcsFMMfFFhFp *item in pouth rucksacks is lower case p
             * 
             * Lowercase item types a through z have priorities 1 through 26.
             * Uppercase item types A through Z have priorities 27 through 52.
             * 
             * Find the item type that appears in both compartments of each rucksack. 
             * What is the sum of the priorities of those item types? */
            
            // Read File:
            string filePath = @"C:\Users\buzz5\OneDrive\Desktop\AOC2022\p3.txt";
            int total = 0; // Initialize a variable to hold the running total
            int index = 0; // Keep track of current line

            try
            {
                // Read all lines from the file into a list
                List<string> lines = File.ReadAllLines(filePath).ToList();

                // Process each line from the file
                /*foreach (string line in lines)
                {
                    // Check if the line has an even number of characters Part 1:
                    *//*if (line.Length % 2 == 0)
                    {
                        // Split the line into halves and calculate the total value of matches
                        var halves = SplitWordInHalf(line);
                        int sum = CalculateTotalValueOfMatches(halves.Item1, halves.Item2);
                        total += sum; // Add the value to the running total
                        Console.WriteLine($"Word: {line}, Total Value: {sum}");
                    }
                    else
                    {
                        // Skip lines with an odd number of characters
                        Console.WriteLine($"Word: {line} - Skipped because it does not have an even number of letters.");
                    }*//*
                }*/

                // Part 2:
                for (index = 0; index < lines.Count; index += 3)
                {
                    // Ensure only three lines
                    if (index + 2 < lines.Count)
                    {
                        string line1 = lines[index];
                        string line2 = lines[index + 1];
                        string line3 = lines[index + 2];

                        // Find matching Letters
                        string commonLetters = FindCommonLetters(line1, line2, line3);
                        int sum = commonLetters.Sum(c => GetValueOfLetter(c));
                        total += sum; // Add the value to the running total
                    }
                }
            }
            catch (Exception ex)
            {
                // Catch and display any exceptions that occur during file processing
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            // Output the total value of all matches
            Console.WriteLine($"Total: {total}");
        }
    }
}
using System;

namespace AOC2022_P2
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Read File:
            string filePath = @"C:\Users\buzz5\OneDrive\Desktop\AOC2022\p2.txt";

            // Score:
            int score_p2 = 0;
            
            // Points:
            int scoreRock = 1;
            int scorePaper = 2;
            int scoreScissors = 3;

            int scoreWin = 6;
            int scoreLose = 0;
            int scoreDraw = 3;

            // Part1:
            // Letter 1 = P1: Rock = A, Paper = B, Scissors = C
            // Letter 2 = P2: Rock = X, Paper = Y, Scissors = Z

    /*      // Scoring rules dictionary for P2
            var outcomes = new Dictionary<(string, string), int>
            {
            // P1's move vs P2's move => P2's score based on the outcome
            { ("A", "X"), scoreDraw + scoreRock }, 
            { ("B", "Y"), scoreDraw + scorePaper }, 
            { ("C", "Z"), scoreDraw + scoreScissors }, 

            { ("A", "Z"), scoreLose + scoreScissors }, 
            { ("B", "X"), scoreLose + scoreRock }, 
            { ("C", "Y"), scoreLose + scorePaper }, 

            { ("C", "X"), scoreWin + scoreRock }, 
            { ("A", "Y"), scoreWin + scorePaper }, 
            { ("B", "Z"), scoreWin + scoreScissors },
            };*/

            // Part 2:
            // Letter 1 = P1: Rock = A, Paper = B, Scissors = C
            // Letter 2 = P2: X = Lose, Y = Draw, Z = Win

            // Scoring rules dictionary for P2
            var outcomes = new Dictionary<(string, string), int>
            {
            // P1's move vs P2's move => P2's score based on the outcome
            { ("A", "X"), scoreLose + scoreScissors }, 
            { ("B", "Y"), scoreDraw + scorePaper }, 
            { ("C", "Z"), scoreWin + scoreRock }, 
    
            { ("A", "Z"), scoreWin + scorePaper }, 
            { ("B", "X"), scoreLose + scoreRock }, 
            { ("C", "Y"), scoreDraw + scoreScissors }, 
    
            { ("C", "X"), scoreLose + scorePaper }, 
            { ("A", "Y"), scoreDraw + scoreRock }, 
            { ("B", "Z"), scoreWin + scoreScissors }, 
            };


            try
            {
                List<string> lines = File.ReadAllLines(filePath).ToList();

                foreach (string line in lines)
                {
                    string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    for(int i = 0; i < parts.Length - 1; i += 2)
                    {
                        var key  = (parts[i], parts[i + 1]);
                        if (outcomes.TryGetValue(key, out var scoreIncrement))
                        {
                            score_p2 += scoreIncrement;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            Console.WriteLine($"Final Score: {score_p2}");
        }
    }
}
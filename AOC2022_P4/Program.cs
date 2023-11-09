using System;

namespace AOC2022_P4
{
    public class Program
    {
        // Functions
        public class Range
        {
            public int Start { get; set; }
            public int End { get; set; }

            // Constructor to initialize the Range
            public Range(int start, int end)
            {
                Start = start;
                End = end;
            }

            //Part 1:
            // Method to check if this range overlaps with another range
            public bool OverlapsWith(Range other)
            {
                // Two ranges overlap if the start of one range is between the start and end of the other range
                // or if the end of one range is between the start and end of the other range
                return (this.Start <= other.End && this.End >= other.Start) ||
                       (other.Start <= this.End && other.End >= this.Start);
            }
        }

        // Function to parse a string into a Range object
        /*public static Range CreateRange(string part)
        {
            string[] bounds = part.Split('-');
            int start = int.Parse(bounds[0]);
            int end = int.Parse(bounds[1]);
            return new Range(start, end);
        }*/

        // Part 2:
        // Range class is assumed to be defined elsewhere in the code

        public static Range CreateRange(string part)
        {
            var bounds = part.Split('-').Select(int.Parse).ToList();
            return new Range(bounds[0], bounds[1]);
        }

        public static bool RangesOverlap(Range range1, Range range2)
        {
            // Ranges overlap if the start of one range is less than or equal to the end of the other range
            // and the end of one range is greater than or equal to the start of the other range
            return range1.Start <= range2.End && range1.End >= range2.Start;
        }

        // End of Functions
        static void Main(string[] args)
            {
                // Every section has unquie ID number and each Elf is assigned to a range of section ID's
                // They elves compare and notice assignments overlap
                // Make a big list of section assignments for each pair
                // 2-4, 6-8 means ELf was assigned to sections 2,3,4 and the second Elf was assigned to 6,7,8
                // Some of the pairs fully contain the other ex. 2-8 fully contains 3-7.
                // How many assignment pairs does one range fully contain the other?

                // Read File
                string filePath = @"C:\Users\buzz5\OneDrive\Desktop\AOC2022\p4.txt";
                int overlappingPairCount = 0; // Counter for overlapping pairs

            try
            {
                    string[] lines = File.ReadAllLines(filePath);
                /*int total = 0; // Initialize counter for fully containing pairs

                for (int i = 0; i < lines.Length; i++)
                {
                    // Split the line into two parts and create Range objects
                    string[] parts = lines[i].Split(',');
                    var range1 = CreateRange(parts[0]);
                    var range2 = CreateRange(parts[1]);

                    // Check if one range fully contains the other and increment the counter
                    if (range1.Start <= range2.Start && range1.End >= range2.End)
                    {
                        total++;
                    }
                    else if (range2.Start <= range1.Start && range2.End >= range1.End)
                    {
                        total++;
                    }
                    */
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    var range1 = CreateRange(parts[0]);
                    var range2 = CreateRange(parts[1]);

                    // Check if the two ranges overlap
                    if (RangesOverlap(range1, range2))
                    {
                        overlappingPairCount++;
                    }
                }
                Console.WriteLine($"Number of overlapping pairs: {overlappingPairCount}");
            }
            catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
using System;

class Program
{
    static void Main(string[] args)
    {
         // Prompt the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        int score = int.Parse(Console.ReadLine());

        // Determine the letter grade
        string letter;
        if (score >= 90)
        {
            letter = "A";
        }
        else if (score >= 80)
        {
            letter = "B";
        }
        else if (score >= 70)
        {
            letter = "C";
        }
        else if (score >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Print the letter grade
        Console.WriteLine($"Your letter grade is: {letter}");

        // Determine if the user passed the course
        if (score >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Unfortunately, you did not pass the course. Better luck next time!");
        }
    }
}
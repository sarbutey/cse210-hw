using System;

class Program
{
    static void Main(string[] args)
    {
       // Initialize the random number generator
        Random random = new Random();
        int magicNumber = random.Next(1, 101);

        // Prompt the user for a guess
        int guess = -1;
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            // Determine if the user needs to guess higher or lower
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}
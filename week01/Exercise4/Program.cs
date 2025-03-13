using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Collect numbers from the user
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        // Compute the sum of the numbers
        int sum = numbers.Sum();
        Console.WriteLine($"The sum is: {sum}");

        // Compute the average of the numbers
        double average = numbers.Average();
        Console.WriteLine($"The average is: {average}");

        // Find the maximum number in the list
        int max = numbers.Max();
        Console.WriteLine($"The largest number is: {max}");
    }
}
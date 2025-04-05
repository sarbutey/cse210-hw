using System;

class Program
{
    static void Main(string[] args)
    {
     while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Activities");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an activity (1-5): ");
            string choice = Console.ReadLine();

            if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    activity = new GratitudeActivity();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(2000);
                    continue;
            }

            activity.Start();
        }
    }
}

abstract class Activity
{
    protected int Duration;

    public void Start()
    {
        DisplayStartingMessage();
        PerformActivity();
        DisplayEndingMessage();
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {GetType().Name}.");
        Console.WriteLine(GetDescription());
        Console.Write("Enter the duration of the activity in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("\nGood job! You have completed the activity.");
        Console.WriteLine($"You spent {Duration} seconds on the {GetType().Name}.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b-");
            Thread.Sleep(250);
            Console.Write("\b\\");
            Thread.Sleep(250);
            Console.Write("\b|");
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected abstract string GetDescription();
    protected abstract void PerformActivity();
}

class BreathingActivity : Activity
{
    protected override string GetDescription()
    {
        return "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breathing.";
    }

    protected override void PerformActivity()
    {
        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(4);
            Console.WriteLine("Breathe out...");
            ShowCountdown(4);
            elapsed += 8;
        }
    }
}

class ReflectionActivity : Activity
{
    private List<string> Prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> Questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    protected override string GetDescription()
    {
        return "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    protected override void PerformActivity()
    {
        Random random = new Random();
        Console.WriteLine(Prompts[random.Next(Prompts.Count)]);
        ShowSpinner(3);

        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.WriteLine(Questions[random.Next(Questions.Count)]);
            ShowSpinner(5);
            elapsed += 5;
        }
    }
}

class ListingActivity : Activity
{
    private List<string> Prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    protected override string GetDescription()
    {
        return "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    protected override void PerformActivity()
    {
        Random random = new Random();
        Console.WriteLine(Prompts[random.Next(Prompts.Count)]);
        Console.WriteLine("You have a few seconds to think before you start listing...");
        ShowCountdown(5);

        int elapsed = 0;
        int count = 0;
        while (elapsed < Duration)
        {
            Console.Write("Enter an item: ");
            Console.ReadLine();
            count++;
            elapsed += 2; // Assume each entry takes 2 seconds
        }

        Console.WriteLine($"You listed {count} items!");
    }
}

class GratitudeActivity : Activity
{
    private List<string> Prompts = new List<string>
    {
        "What are three things you are grateful for today?",
        "Who is someone you are grateful to have in your life?",
        "What is a recent event that made you feel grateful?",
        "What is something about yourself that you are grateful for?"
    };

    protected override string GetDescription()
    {
        return "This activity will help you focus on gratitude by reflecting on the positive aspects of your life.";
    }

    protected override void PerformActivity()
    {
        Random random = new Random();
        Console.WriteLine(Prompts[random.Next(Prompts.Count)]);
        Console.WriteLine("Take a moment to reflect on this prompt...");
        ShowSpinner(5);

        Console.WriteLine("Write down your thoughts:");
        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.Write("Enter a thought: ");
            Console.ReadLine();
            elapsed += 5; // Assume each entry takes 5 seconds
        }

        Console.WriteLine("Thank you for reflecting on gratitude!");
    }
}
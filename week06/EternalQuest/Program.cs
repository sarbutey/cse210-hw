using System;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int totalScore = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest");
            Console.WriteLine($"Total Score: {totalScore}");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option (1-6): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal(goals);
                    break;
                case "2":
                    totalScore += RecordEvent(goals);
                    break;
                case "3":
                    ShowGoals(goals);
                    break;
                case "4":
                    SaveGoals(goals, totalScore);
                    break;
                case "5":
                    totalScore = LoadGoals(goals);
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateNewGoal(List<Goal> goals)
    {
        Console.WriteLine("Select Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose an option (1-3): ");
        string choice = Console.ReadLine();

        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter the goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter the points for completing the goal: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter the number of times to complete the goal: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter the bonus points for completing the goal: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static int RecordEvent(List<Goal> goals)
    {
        Console.WriteLine("Select a goal to record:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
        Console.Write("Choose a goal: ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < goals.Count)
        {
            return goals[choice].RecordEvent();
        }
        else
        {
            Console.WriteLine("Invalid choice.");
            return 0;
        }
    }

    static void ShowGoals(List<Goal> goals)
    {
        Console.WriteLine("Goals:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.GetStatus());
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    static void SaveGoals(List<Goal> goals, int totalScore)
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(totalScore);
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.ToString());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    static int LoadGoals(List<Goal> goals)
    {
        if (File.Exists("goals.txt"))
        {
            goals.Clear();
            string[] lines = File.ReadAllLines("goals.txt");
            int totalScore = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                if (type == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(parts[4]);
                    goals.Add(new SimpleGoal(name, description, points, isComplete));
                }
                else if (type == "EternalGoal")
                {
                    goals.Add(new EternalGoal(name, description, points));
                }
                else if (type == "ChecklistGoal")
                {
                    int count = int.Parse(parts[4]);
                    int targetCount = int.Parse(parts[5]);
                    int bonusPoints = int.Parse(parts[6]);
                    goals.Add(new ChecklistGoal(name, description, points, targetCount, bonusPoints, count));
                }
            }

            Console.WriteLine("Goals loaded successfully.");
            return totalScore;
        }
        else
        {
            Console.WriteLine("No saved goals found.");
            return 0;
        }
    }
}

abstract class Goal
{
    protected string Name;
    protected string Description;
    protected int Points;

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public abstract int RecordEvent();
    public abstract string GetStatus();
    public override string ToString()
    {
        return $"{GetType().Name}|{Name}|{Description}|{Points}";
    }
}

class SimpleGoal : Goal
{
    private bool IsComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        IsComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            IsComplete = true;
            return Points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return $"[ {(IsComplete ? "X" : " ")} ] {Name} ({Description})";
    }

    public override string ToString()
    {
        return base.ToString() + $"|{IsComplete}";
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return Points;
    }

    public override string GetStatus()
    {
        return $"[ ] {Name} ({Description})";
    }
}

class ChecklistGoal : Goal
{
    private int Count;
    private int TargetCount;
    private int BonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, int count = 0)
        : base(name, description, points)
    {
        TargetCount = targetCount;
        BonusPoints = bonusPoints;
        Count = count;
    }

    public override int RecordEvent()
    {
        Count++;
        if (Count == TargetCount)
        {
            return Points + BonusPoints;
        }
        return Points;
    }

    public override string GetStatus()
    {
        return $"[ {(Count >= TargetCount ? "X" : " ")} ] {Name} ({Description}) -- Completed {Count}/{TargetCount} times";
    }

    public override string ToString()
    {
        return base.ToString() + $"|{Count}|{TargetCount}|{BonusPoints}";
    }
}
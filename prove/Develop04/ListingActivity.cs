namespace MindfulnessProgram;

public class ListingActivity : MindfulnessActivity
{
    private readonly string[] _prompts =
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void PerformActivity()
    {
        string prompt = _prompts[Random.Next(_prompts.Length)];
        Console.WriteLine();
        Console.WriteLine("Listing prompt:");
        Console.WriteLine(prompt);
        Console.WriteLine("Take a few seconds to think before you begin listing items.");
        ShowCountdown(3, "Thinking");

        int itemCount = 0;
        int elapsedSeconds = 0;

        while (elapsedSeconds < DurationSeconds)
        {
            Console.Write($"Enter item {itemCount + 1} (or type 'done' to finish): ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter a valid item.");
                continue;
            }

            if (input.Equals("done", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            itemCount++;
            elapsedSeconds += 2;

            if (elapsedSeconds >= DurationSeconds)
            {
                break;
            }

            Console.WriteLine($"{DurationSeconds - elapsedSeconds} seconds remaining.");
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {itemCount} items.");
    }

    private void ShowCountdown(int seconds, string label)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write($"\r{label}... {i}");
            Thread.Sleep(1000);
        }

        Console.WriteLine();
    }
}

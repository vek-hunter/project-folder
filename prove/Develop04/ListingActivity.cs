using System;
using System.Collections.Generic;

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

    private readonly Random _random = new();

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void PerformActivity()
    {
        string prompt = _prompts[_random.Next(_prompts.Length)];
        Console.WriteLine("List as many things as you can as it relates to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        List<string> itemsGathered = new();
        DateTime endTime = DateTime.Now.AddSeconds(durationSeconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                itemsGathered.Add(input);
            }
        }

        Console.WriteLine($"\nYou listed {itemsGathered.Count} items!");
    }
}

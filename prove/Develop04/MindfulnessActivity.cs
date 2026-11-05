using System;
using System.Threading;

namespace MindfulnessProgram;

public abstract class MindfulnessActivity
{
    protected string ActivityName { get; }
    protected string Description { get; }
    protected int DurationSeconds { get; private set; }
    protected Random Random { get; } = new Random();

    protected MindfulnessActivity(string activityName, string description)
    {
        ActivityName = activityName;
        Description = description;
    }

    public void Run()
    {
        DurationSeconds = GetDuration();
        ShowStartMessage();
        PerformActivity();
        ShowEndingMessage();
    }

    private int GetDuration()
    {
        while (true)
        {
            Console.Write("How long would you like this session to last in seconds? ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int seconds) && seconds > 0)
            {
                return seconds;
            }

            Console.WriteLine("Please enter a positive number of seconds.");
        }
    }

    protected void ShowStartMessage()
    {
        Console.WriteLine();
        Console.WriteLine($"Activity: {ActivityName}");
        Console.WriteLine(Description);
        Console.WriteLine("Get ready to begin...");
        PauseWithCountdown(3, "Preparing");
    }

    protected void PauseWithCountdown(int seconds, string message)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write($"\r{message}... {i} seconds");
            Thread.Sleep(1000);
        }

        Console.WriteLine();
    }

    protected void ShowSpinner(int seconds, string message)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int frameIndex = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write($"\r{message} {frames[frameIndex % frames.Length]}");
            Thread.Sleep(250);
            frameIndex++;
        }

        Console.WriteLine();
    }

    protected void ShowEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("You have done a good job!");
        PauseWithCountdown(3, "Finishing");
        Console.WriteLine($"You have completed the {ActivityName} activity for {DurationSeconds} seconds.");
        PauseWithCountdown(3, "Wrapping up");
    }

    protected abstract void PerformActivity();
}

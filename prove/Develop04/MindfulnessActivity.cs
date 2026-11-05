using System;
using System.Threading;

namespace MindfulnessProgram;

public abstract class MindfulnessActivity
{
    protected string activityName;
    protected string description;
    protected int durationSeconds;
    protected Random random;

    protected MindfulnessActivity(string activityName, string description)
    {
        this.activityName = activityName;
        this.description = description;
        this.random = new Random();
    }

    public void Run()
    {
        durationSeconds = GetDuration();
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
        Console.Clear();
        Console.WriteLine("Activity: " + activityName);
        Console.WriteLine(description);
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(3, "Preparing");
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            string backspaces = new string('\b', i.ToString().Length);
            string spaces = new string(' ', i.ToString().Length);
            Console.Write(backspaces + spaces + backspaces);
        }
    }

    protected void ShowSpinner(int seconds, string message)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int frameIndex = 0;

        Console.WriteLine(message + "...");
        while (DateTime.Now < endTime)
        {
            Console.Write("\r" + frames[frameIndex % frames.Length]);
            Thread.Sleep(250);
            frameIndex++;
        }

        Console.Write("\b \b");
    }

    protected void ShowEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("You have done a good job!");
        ShowSpinner(3, "Finishing");
        Console.WriteLine("You have completed the " + activityName + " activity for " + durationSeconds + " seconds.");
        ShowSpinner(3, "Wrapping up");
    }

    protected abstract void PerformActivity();
}

namespace MindfulnessProgram;

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        int elapsedSeconds = 0;
        bool breatheIn = true;

        while (elapsedSeconds < DurationSeconds)
        {
            int cycleLength = Math.Min(3, DurationSeconds - elapsedSeconds);
            string message = breatheIn ? "Breathe in..." : "Breathe out...";

            Console.WriteLine();
            Console.WriteLine(message);
            ShowCountdown(cycleLength, breatheIn ? "Inhale" : "Exhale");

            elapsedSeconds += cycleLength;
            breatheIn = !breatheIn;
        }
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

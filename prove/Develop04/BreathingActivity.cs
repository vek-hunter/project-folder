using System;
using System.Threading;

namespace MindfulnessProgram;

public class BreathingActivity : MindfulnessActivity
{
    private const int BreathDuration = 4;

    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(durationSeconds);
        bool breatheIn = true;

        while (DateTime.Now < endTime)
        {
            if (breatheIn)
            {
                Console.Write("\nBreathe in... ");
                ShowCountdown(BreathDuration);
            }
            else
            {
                Console.Write("\nBreathe out... ");
                ShowCountdown(BreathDuration);
            }

            Console.WriteLine();
            breatheIn = !breatheIn;
        }
    }
}

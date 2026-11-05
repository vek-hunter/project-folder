using System;

namespace MindfulnessProgram;

public class Program
{
    public static void Main()
    {
        bool running = true;

        while (running)
        {
            try
            {
                Console.Clear();
            }
            catch (IOException)
            {
                // Some environments, such as redirected input/output, do not support clearing the console.
            }

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an activity: ");

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    new BreathingActivity().Run();
                    break;
                case "2":
                    new ReflectionActivity().Run();
                    break;
                case "3":
                    new ListingActivity().Run();
                    break;
                case "4":
                    Console.WriteLine("Thank you for taking time to be mindful today.");
                    running = false;
                    break;
                default:
                    Console.WriteLine("That is not a valid option. Please try again.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}

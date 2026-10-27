using System;

namespace JournalProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            PromptGenerator promptGenerator = new PromptGenerator();
            bool running = true;

            Console.WriteLine("Welcome to the Journal Program!");

            while (running)
            {
                Console.WriteLine("Please select one of the following choices:");
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Load");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Quit");
                Console.Write("What would you like to do? ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write(" ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();

                    Entry newEntry = new Entry(date, prompt, response);
                    journal.AddEntry(newEntry);
                }
                else if (choice == "2")
                {
                    journal.DisplayAll();
                }
                else if (choice == "3")
                {
                    Console.Write("What is the filename? ");
                    string fileName = Console.ReadLine();
                    journal.LoadFromFile(fileName);
                }
                else if (choice == "4")
                {
                    Console.Write("What is the filename? ");
                    string fileName = Console.ReadLine();
                    journal.SaveToFile(fileName);
                }
                else if (choice == "5")
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.\n");
                }
            }
        }
    }
}

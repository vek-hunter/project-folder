using System;

namespace JournalProgram
{
    public class Entry
    {
        private string _date;
        private string _prompt;
        private string _response;

        public Entry(string date, string prompt, string response)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
        }

        public void Display()
        {
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine($"Prompt: {Prompt}");
            Console.WriteLine($"Response: {Response}");
            Console.WriteLine(new string('-', 50));
        }
    }
}

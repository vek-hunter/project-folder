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
            _date = date;
            _prompt = prompt;
            _response = response;
        }
        public string GetPrompt() {
           return _prompt;
        }
        public string GetResponse() {
           return _response;
        }
        public string GetDate() {
           return _date;
        }
        public void Display() {
           
            Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
            Console.WriteLine($"{_response}");
            Console.WriteLine();
        }
   }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace JournalProgram
{
    public class Journal
    {
        private List<Entry> _entries = new List<Entry>();

        public Journal()
        {
        }

        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);
        }

        public List<Entry> GetEntries()
        {
            return _entries;
        }

        public void DisplayAll()
        {
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }

        public void SaveToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine($"{entry.GetDate()}~|~{entry.GetPrompt()}~|~{entry.GetResponse()}");
                }
            }
        }

        public void LoadFromFile(string fileName)
        {
            _entries.Clear();

            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    string[] parts = line.Split("~|~");

                    if (parts.Length >= 3)
                    {
                        string date = parts[0];
                        string prompt = parts[1];
                        string response = parts[2];

                        if (parts.Length > 3)
                        {
                            response = string.Join("~|~", parts, 2, parts.Length - 2);
                        }

                        Entry newEntry = new Entry(date, prompt, response);
                        _entries.Add(newEntry);
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}

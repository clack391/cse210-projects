/*
    Enhancements Beyond Core Requirements:
    --------------------------------------
    1. **Mood Tracker** - Users can rate their mood (1-10) for each journal entry.
    2. **JSON-Based Storage** - Journal entries are saved in JSON format instead of plain text, improving structure and compatibility.

    These additions enhance user experience and make the journal more insightful and useful.
*/



using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        string choice;

        do
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SaveToFile();
                    break;
                case "4":
                    journal.LoadFromFile();
                    break;
            }
        } while (choice != "5");
    }
}

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();
    private static readonly List<string> prompts = new List<string>
    {
        "What made you smile today?",
        "Describe a challenge you faced and how you handled it.",
        "What is something new you learned today?",
        "Write about a moment you felt grateful today.",
        "What inspired you today?"
    };

    public void AddEntry()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine($"\n{prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        
        Console.Write("Rate your mood (1-10): ");
        int mood = int.Parse(Console.ReadLine());
        
        JournalEntry entry = new JournalEntry(prompt, response, mood);
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        string json = JsonConvert.SerializeObject(entries, Formatting.Indented);
        File.WriteAllText(filename, json);
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            entries = JsonConvert.DeserializeObject<List<JournalEntry>>(json);
            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}

class JournalEntry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public int Mood { get; set; }

    public JournalEntry(string prompt, string response, int mood)
    {
        Date = DateTime.Now.ToShortDateString();
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    public override string ToString()
    {
        return $"\nDate: {Date}\nPrompt: {Prompt}\nResponse: {Response}\nMood: {Mood}/10\n";
    }
}

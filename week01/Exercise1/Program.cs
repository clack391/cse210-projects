using System;

class Program
{
    static void Main()
    {
        // Prompt for first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Prompt for last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Print the name in the specified format
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}

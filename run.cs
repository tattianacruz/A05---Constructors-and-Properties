/*
* file : run.cs
* project : prog1385 - object oriented programming
* programmer : luisa tatiana cruz diaz
* first version : 2024-02-18
* description :
* this program defines a class called 'run' that provides a console-based menu system
* for managing a collection of members. it allows adding, listing, deleting members,
* as well as saving and loading member data from a file.
*/

using System;
using System.Collections.Generic;
using System.IO;

public class Run
{
    // list to store members
    private List<Member> members = new List<Member>(); 

    // displays a menu and processes user input until they choose to exit
    public void Execute()
    {
        bool running = true;
        while (running)
        {
            UI.Display("1. Add member\n2. List members\n3. Delete member\n4. Save to file\n5. Load from file\n6. Exit");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": AddMember(); break;
                case "2": ListMembers(); break;
                case "3": DeleteMember(); break;
                case "4": SaveToFile(); break;
                case "5": LoadFromFile(); break;
                case "6": running = false; break;
                default: UI.Display("Invalid option"); break;
            }
        }
    }

    // adds a new member after collecting input from the user
    void AddMember()
    {
        UI.Display("Enter first name:");
        string first = Console.ReadLine();
        UI.Display("Enter last name:");
        string last = Console.ReadLine();
        UI.Display("Enter email:");
        string mail = Console.ReadLine();
        UI.Display("Enter birthdate (yyyy-mm-dd):");

        DateTime birth;
        while (!DateTime.TryParse(Console.ReadLine(), out birth))
        {
            UI.Display("Invalid date. Try again (yyyy-mm-dd):");
        }

        members.Add(new Member(first, last, mail, birth));
        UI.Display("Member added successfully.");
    }

    // lists all members with their details
    void ListMembers()
    {
        foreach (var m in members)
        {
            UI.Display($"ID: {m.Id}, Name: {m.GetName()}, Age: {m.CalculateAge()}, Email: {m.Email}, Birthdate: {m.Birthdate:yyyy-MM-dd}");
        }
    }

    // deletes a member by id if it exists
    void DeleteMember()
    {
        UI.Display("Enter ID to delete:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var member = members.Find(m => m.Id == id);
            if (member != null)
            {
                UI.Display("Confirm deletion? (y/n)");
                if (Console.ReadLine().ToLower() == "y")
                {
                    members.Remove(member);
                    UI.Display("Member deleted.");
                }
            }
            else
            {
                UI.Display("Member not found.");
            }
        }
        else
        {
            UI.Display("Invalid ID. Must be a number.");
        }
    }

    // saves the members list to a text file
    void SaveToFile()
    {
        UI.Display("Enter file name:");
        string file = Console.ReadLine();

        if (File.Exists(file))
        {
            UI.Display("File exists. Overwrite? (y/n)");
            if (Console.ReadLine().ToLower() != "y")
            {
                UI.Display("Save cancelled.");
                return;
            }
        }

        File.WriteAllLines(file, members.ConvertAll(m => m.ToString()));
        UI.Display("Members saved to file.");
    }

    // loads the members list from a text file
    void LoadFromFile()
    {
        UI.Display("Enter file name:");
        string file = Console.ReadLine();

        if (File.Exists(file))
        {
            UI.Display("Overwrite current data? (y/n)");
            if (Console.ReadLine().ToLower() != "y")
            {
                UI.Display("Load cancelled.");
                return;
            }

            members.Clear();

            foreach (string line in File.ReadAllLines(file))
            {
                var parts = line.Split('|');
                members.Add(new Member(
                    int.Parse(parts[0]),
                    parts[1],
                    parts[2],
                    parts[3],
                    DateTime.Parse(parts[4])
                ));
            }

            UI.Display("Members loaded from file.");
        }
        else
        {
            UI.Display("File not found.");
        }
    }
}

/*
* file : program.cs
* project : prog1385 - object oriented programming
* programmer : luisa tatiana cruz diaz
* first version : 2024-02-18
* description :
* this is the entry point of the application. it creates an instance of the 'run' class
* and starts the execution of the program by calling the 'execute' method.
*/

using System;

public class Program
{
    // main method: entry point of the program
    public static void Main()
    {
        // create an instance of the 'run' class to manage members
        Run memberManager = new Run();

        // start the execution of the menu-driven program
        memberManager.Execute();
    }
}

/* 
* file : UI.cs
* project : prog1385 - object oriented programming
* programmer : luisa tatiana cruz diaz
* first version : 2024-02-18
* description :
* this program defines a static class 'UI' that provides a simple method to display messages
* to the console. it is intended to handle basic output operations for the project.
*/

using System;

public static class UserInterface
{
    // displays a message to the console

    public static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}

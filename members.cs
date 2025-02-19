/*
* file : member.cs
* project : prog1385 - object oriented programming
* programmer : luisa tatiana cruz diaz
* first version : 2024-02-18
* description :
* this program defines a class called 'member' that represents a person with basic information
* such as id, first name, last name, email, and birthdate. it also provides methods to get the full name,
* calculate the age, and convert the member's information into a string format.
*/

using System;

public class Member
{
    private static int nextMemberId = 1; // keeps track of the next unique id to assign to a new member
    public int MemberId { get; } // unique identifier for each member
    public string FirstName { get; set; } // member's first name
    public string LastName { get; set; } // member's last name
    public string EmailAddress { get; set; } // member's email address
    public DateTime DateOfBirth { get; set; } // member's birthdate

    // constructor to create a new member with a unique id
    public Member(string firstName, string lastName, string emailAddress, DateTime dateOfBirth)
    {
        MemberId = nextMemberId++;
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        DateOfBirth = dateOfBirth;
    }

    // constructor to create a member with a specified id (used for loading existing members)
    public Member(int memberId, string firstName, string lastName, string emailAddress, DateTime dateOfBirth)
    {
        MemberId = memberId;
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        DateOfBirth = dateOfBirth;

        // update the nextMemberId if the provided id is greater than or equal to the current one
        if (memberId >= nextMemberId)
        {
            nextMemberId = memberId + 1;
        }
    }

    // returns the member's full name in the format 'last name, first name'
    public string GetFullName()
    {
        return $"{LastName}, {FirstName}";
    }

    // calculates the member's age based on the current date and their birthdate
    public int GetAge()
    {
        int age = DateTime.Today.Year - DateOfBirth.Year;
        if (DateTime.Today.DayOfYear < DateOfBirth.DayOfYear)
        {
            age--;
        }
        return age;
    }

    // returns a string representation of the member's details in a pipe-separated format
    public override string ToString()
    {
        return $"{MemberId}|{FirstName}|{LastName}|{EmailAddress}|{DateOfBirth:yyyy-MM-dd}";
    }
}

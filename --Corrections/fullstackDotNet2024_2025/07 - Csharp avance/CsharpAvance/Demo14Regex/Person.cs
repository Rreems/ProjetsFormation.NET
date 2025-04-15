using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo14Regex;


internal class Person
{
    private string _firstName;
    private string _lastName;
    private string _email;
    private string _phone;
    private int _age;

    public Person(string firstName, string lastName, int age, string email, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Email = email;
        Phone = phone;
    }

    public string FirstName
    {
        get => _firstName;
        set
        {
            if (Tools.IsName(value))
                _firstName = value;
            else
                throw new FormatException("Erreur prénom...");
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (Tools.IsName(value))
                _lastName = value;
            else
                throw new FormatException("Erreur nom...");
        }
    }

    public int Age
    {
        get => _age;
        set
        {
            if (value > 0 && value < 126)
                _age = value;
            else
                throw new FormatException("Erreur age...");
        }
    }
    public string Email
    {
        get => _email;
        set
        {
            if (Tools.IsEmail(value))
                _email = value;
            else
                throw new FormatException("Erreur email...");
        }
    }

    public string Phone
    {
        get => _phone;
        set
        {
            if (Tools.IsPhone(value))
                _phone = value;
            else
                throw new FormatException("Erreur phone...");
        }
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} - {Age} ans \n\tEmail : {Email}\n\tPhone : {Phone}";
    }
}

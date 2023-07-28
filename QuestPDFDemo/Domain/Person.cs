using QuestPDF.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestPDFDemo.Domain;

public abstract class Base
{

}

public class Customer : Base
{
    public string Name { get; set; }
}

public class Person : Base
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Customer Customer { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    public Person()
    {
        
    }

    public Person(string firstName, string lastName)
        : this()
    {
        FirstName = firstName;
        LastName = lastName;
    }
}

public class Event : Base
{   
    public string Title { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public List<Person> Members { get; set; } = new List<Person>();
    public string Slug { get; set; }
    public Address Organizer { get; set; }

    public string Comments { get; set; }

    public Event()
    {
        
    }
    public Event(string title, DateTime from, DateTime to)
        :this()
    {
        Title = title;
        From = from;
        To = to;
    }

    public Event(string title, DateTime from, DateTime to, List<Person> members) : this(title, from, to)
    {
        Members = members;
    }
}

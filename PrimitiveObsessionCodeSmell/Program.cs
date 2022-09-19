{ 
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


    //primitive obssesion is the data type can take in any value and is too general like name
    //https://hackernoon.com/what-is-primitive-obsession-and-how-can-we-fix-it-wh2f33ki


    var personId = new PersonId("my-id");

    personId =  PersonId.New();


    // how to initialise



}


#region

//public class Person
//{
//    public Person(string id, string firstName, string lastName, string address, string postcode, string city, string country)
//    {
//        // initialisation logic
//    }

//    public string Id { get; set; }

//    public string FirstName { get; set; }
//    public string LastName { get; set; }

//    public string Address { get; set; }
//    public string PostCode { get; set; }
//    public string City { get; set; }
//    public string Country { get; set; }

//    public void ChangeAddress(string address, string postcode, string city, string country)
//    {
//        // change address logic
//    }
//}
#endregion

//refactor

//break out into single responsibility for preson and address
// The important part of avoiding Primitive Obsession is encapsulating those primitives into well defined objects that actually represent their meaning.
//Domain-driven design (DDD) advocates modeling based on the reality of business as relevant to your use cases.
// Example: string for postcode but Uk post code and US post code are different

//consume nuget package like valueof
//https://www.youtube.com/watch?v=h4uldNA1JUE&t=372s

public class Address
{
    public Address(string address, string postCode, string city, string country)
    {
        // initialisation logic
    }

    public string FullAddress { get; set; }
    public string PostCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}

public class Person
{
    public Person(string id, string firstName, string lastName, Address address)
    {
        // initialisation logic
    }

    public string Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Address Address { get; set; }

    public record PersonId(string Value);
}


public readonly struct PersonId : IComparable<PersonId>, IEquatable<PersonId>
{
    public string Value { get; }

    public PersonId(string value)
    {
        Value = value;
    }

    public static PersonId New() => new PersonId(Guid.NewGuid().ToString());

    public bool Equals(PersonId other) => this.Value.Equals(other.Value);
    public int CompareTo(PersonId other) => Value.CompareTo(other.Value);

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj is PersonId other && Equals(other);
    }

    public override int GetHashCode() => Value.GetHashCode();
    public override string ToString() => Value.ToString();

    public static bool operator ==(PersonId a, PersonId b) => a.CompareTo(b) == 0;
    public static bool operator !=(PersonId a, PersonId b) => !(a == b);
}
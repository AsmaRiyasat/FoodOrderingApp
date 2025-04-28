public class Customers
{
    private string? name;
    private string? phoneNumber;

    public Customers(string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
    }
    public Customers() { }



    public string Name
    {
        get
        {
            return name!;
        }
        set
        {
            name = value;
        }
    }

    public string PhoneNumber
    {
        get
        {
            return phoneNumber!;
        }
        set
        {
            phoneNumber = value;
        }
    }



    public override string ToString()
    {
        return $"{name}, {phoneNumber}";
    }
}
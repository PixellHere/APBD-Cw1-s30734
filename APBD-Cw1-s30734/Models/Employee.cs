namespace APBD_Cw1_s30734.Models;

public class Employee : User
{
    string _role;
    int _salary;

    public Employee(string firstName, string lastName, string role, int salary) : base(firstName, lastName, APBD_Cw1_s30734.Models.UserType.Employee)
    {
        _role = role;
        _salary = salary;
    }

    public string Role
    {
        get => _role;
        set => _role = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Salary
    {
        get => _salary;
        set => _salary = value;
    }
}
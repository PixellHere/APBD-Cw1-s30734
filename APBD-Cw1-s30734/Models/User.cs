namespace APBD_Cw1_s30734.Models;

public abstract class User
{
    string _uuid;
    string _firstName;
    string _lastName;
    UserType? _userType;

    protected User(string firstName, string lastName, UserType userType)
    {
        _uuid = Guid.NewGuid().ToString();
        _firstName = firstName;
        _lastName = lastName;
        _userType = userType;
    }

    public string Uuid
    {
        get => _uuid;
    }

    public string FirstName
    {
        get => _firstName;
        set => _firstName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string LastName
    {
        get => _lastName;
        set => _lastName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public UserType? UserType
    {
        get => _userType;
        set => _userType = value;
    }
}

public enum UserType
{
    Employee,
    Student
}
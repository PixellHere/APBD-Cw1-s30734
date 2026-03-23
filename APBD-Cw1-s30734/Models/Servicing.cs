namespace APBD_Cw1_s30734.Models;

public class Servicing
{
    Item _item;
    User _fixer;
    DateTime _startDate;
    DateTime _expectedEndDate;
    String _faultDescription;

    public static List<Servicing> ItemsInService = new List<Servicing>();

    public Servicing(Item item, User fixer, DateTime startDate, DateTime expectedEndDate, string faultDescription)
    {
        _item = item;
        _fixer = fixer;
        _startDate = startDate;
        _expectedEndDate = expectedEndDate;
        _faultDescription = faultDescription;
    }

    public Item Item
    {
        get => _item;
        set => _item = value ?? throw new ArgumentNullException(nameof(value));
    }

    public User Fixer
    {
        get => _fixer;
        set => _fixer = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DateTime StartDate
    {
        get => _startDate;
        set => _startDate = value;
    }

    public DateTime ExpectedEndDate
    {
        get => _expectedEndDate;
        set => _expectedEndDate = value;
    }

    public string FaultDescription
    {
        get => _faultDescription;
        set => _faultDescription = value ?? throw new ArgumentNullException(nameof(value));
    }
}
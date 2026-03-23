namespace APBD_Cw1_s30734.Models;

public class ItemRental
{
    public static Dictionary<int, double> RentCosts = new Dictionary<int, double>
    {
        { 1, 2.99 },
        { 2, 3.99 },
        { 3, 4.99 },
        { 4, 5.99 },
        { 5, 7.99 },
        { 6, 8.99 },
        { 7, 9.99 },
        { 15, 20.99 },
        { 30, 44.99 }
    };
    
    public static Dictionary<int, double> DelayCosts = new Dictionary<int, double>
    {
        { 1, 5.99 },
        { 2, 7.99 },
        { 3, 10.99 },
        { 4, 12.99 },
        { 5, 14.99 },
        { 6, 16.99 },
        { 7, 18.99 }
    };

    public static List<ItemRental> RentedItems = new List<ItemRental>();

    User _renter;
    Item _item;
    DateTime _startDate;
    DateTime _endDate;
    bool _isReturned;
    double _rentCost;
    double _delayCost;

    public ItemRental(User renter, Item item, DateTime startDate, DateTime endDate)
    {
        _renter = renter;
        _item = item;
        _startDate = startDate;
        _endDate = endDate;
        _isReturned = false;
        _rentCost = (endDate - startDate).TotalDays;
        _delayCost = 0;
    }

    public static Dictionary<int, double> RentCosts1
    {
        get => RentCosts;
        set => RentCosts = value ?? throw new ArgumentNullException(nameof(value));
    }

    public static Dictionary<int, double> DelayCosts1
    {
        get => DelayCosts;
        set => DelayCosts = value ?? throw new ArgumentNullException(nameof(value));
    }

    public User Renter
    {
        get => _renter;
        set => _renter = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Item Item
    {
        get => _item;
        set => _item = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DateTime StartDate
    {
        get => _startDate;
        set => _startDate = value;
    }

    public DateTime EndDate
    {
        get => _endDate;
        set => _endDate = value;
    }

    public bool IsReturned
    {
        get => _isReturned;
        set => _isReturned = value;
    }

    public double RentCost
    {
        get => _rentCost;
        set => _rentCost = value;
    }

    public double DelayCost
    {
        get => _delayCost;
        set => _delayCost = value;
    }
}
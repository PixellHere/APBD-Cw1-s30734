namespace APBD_Cw1_s30734.Models;
public abstract class Item
{
    public static List<Item> AvailableItems = new List<Item>();
    
    string _uuid;
    string _name;
    bool _isAvailable;
    int _yearOfManufacture;
    string _description;
    string _whyNotAvailable;

    public Item(string name, bool isAvailable, int yearOfManufacture, string description, string whyNotAvailable)
    {
        _uuid = Guid.NewGuid().ToString();
        _name = name;
        _isAvailable = isAvailable;
        _yearOfManufacture = yearOfManufacture;
        _description = description;
        _whyNotAvailable = whyNotAvailable;
    }
    
    public Item(string name, bool isAvailable, int yearOfManufacture, string description)
    {
        _uuid = Guid.NewGuid().ToString();
        _name = name;
        _isAvailable = isAvailable;
        _yearOfManufacture = yearOfManufacture;
        _description = description;
        if(isAvailable)
            _whyNotAvailable = "";
        else
            _whyNotAvailable = "Not info provided";
    }

    public string Uuid
    {
        get => _uuid;
    }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public bool IsAvailable
    {
        get => _isAvailable;
        set => _isAvailable = value;
    }

    public int YearOfManufacture
    {
        get => _yearOfManufacture;
        set => _yearOfManufacture = value;
    }

    public string Description
    {
        get => _description;
        set => _description = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string WhyNotAvailable
    {
        get => _whyNotAvailable;
        set => _whyNotAvailable = value;
    }
}
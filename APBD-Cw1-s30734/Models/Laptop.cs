namespace APBD_Cw1_s30734.Models;

public class Laptop : Item
{ 
    string _operatingSystem;
    string _processorArchitecture;

    public Laptop(string name, bool isAvailable, int yearOfManufacture, string description, string whyNotAvailable, string operatingSystem, string processorArchitecture) : base(name, isAvailable, yearOfManufacture, description, whyNotAvailable)
    {
        _operatingSystem = operatingSystem;
        _processorArchitecture = processorArchitecture;
    }

    public Laptop(string name, bool isAvailable, int yearOfManufacture, string description, string operatingSystem, string processorArchitecture) : base(name, isAvailable, yearOfManufacture, description)
    {
        _operatingSystem = operatingSystem;
        _processorArchitecture = processorArchitecture;
    }

    public string OperatingSystem
    {
        get => _operatingSystem;
        set => _operatingSystem = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string ProcessorArchitecture
    {
        get => _processorArchitecture;
        set => _processorArchitecture = value ?? throw new ArgumentNullException(nameof(value));
    }
}
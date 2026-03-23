namespace APBD_Cw1_s30734.Models;
public class Camera : Item
{
    int _batteryLife;
    bool _hasAutoFocus;

    public Camera(string name, bool isAvailable, int yearOfManufacture, string description, string whyNotAvailable, int batteryLife, bool hasAutoFocus) : base(name, isAvailable, yearOfManufacture, description, whyNotAvailable)
    {
        _batteryLife = batteryLife;
        _hasAutoFocus = hasAutoFocus;
    }

    public Camera(string name, bool isAvailable, int yearOfManufacture, string description, int batteryLife, bool hasAutoFocus) : base(name, isAvailable, yearOfManufacture, description)
    {
        _batteryLife = batteryLife;
        _hasAutoFocus = hasAutoFocus;
    }

    public int BatteryLife
    {
        get => _batteryLife;
        set => _batteryLife = value;
    }

    public bool HasAutoFocus
    {
        get => _hasAutoFocus;
        set => _hasAutoFocus = value;
    }
}
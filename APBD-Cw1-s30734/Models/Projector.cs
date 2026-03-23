namespace APBD_Cw1_s30734.Models;

public class Projector : Item
{
    string _videoQuality;
    bool _hasSpeaker;

    public Projector(string name, bool isAvailable, int yearOfManufacture, string description, string whyNotAvailable, string videoQuality, bool hasSpeaker) : base(name, isAvailable, yearOfManufacture, description, whyNotAvailable)
    {
        _videoQuality = videoQuality;
        _hasSpeaker = hasSpeaker;
    }

    public Projector(string name, bool isAvailable, int yearOfManufacture, string description, string videoQuality, bool hasSpeaker) : base(name, isAvailable, yearOfManufacture, description)
    {
        _videoQuality = videoQuality;
        _hasSpeaker = hasSpeaker;
    }

    public string VideoQuality
    {
        get => _videoQuality;
        set => _videoQuality = value ?? throw new ArgumentNullException(nameof(value));
    }

    public bool HasSpeaker
    {
        get => _hasSpeaker;
        set => _hasSpeaker = value;
    }
}
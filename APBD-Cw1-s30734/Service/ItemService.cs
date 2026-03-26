using APBD_Cw1_s30734.Models;

namespace APBD_Cw1_s30734.Service;

public class ItemService
{
    public ItemService()
    {
    }

    public void AddLaptopToInventory(string name, bool isAvailable, int yearOfManufacture, string description, string whyNotAvailable, string operatingSystem, string processorArchitecture)
    {
        Laptop laptop;
        
        if (whyNotAvailable.Equals(""))
        {
            laptop = new Laptop(name, isAvailable, yearOfManufacture, description, operatingSystem, processorArchitecture);

        }
        else
        {
            laptop = new Laptop(name, isAvailable, yearOfManufacture, description, whyNotAvailable, operatingSystem,
                processorArchitecture);
        }
        
        Item.AvailableItems.Add(laptop);
    }
    
    public void AddProjectorToInventory(string name, bool isAvailable, int yearOfManufacture, string description, string whyNotAvailable, string videoQuality, bool hasSpeaker)
    {
        Projector projector;
        
        if (whyNotAvailable.Equals(""))
        {
            projector = new Projector(name, isAvailable, yearOfManufacture, description, videoQuality, hasSpeaker);

        }
        else
        {
            projector = new Projector(name, isAvailable, yearOfManufacture, description, whyNotAvailable, videoQuality,
                hasSpeaker);
        }
        
        Item.AvailableItems.Add(projector);
    }
    
    public void AddCameraToInventory(string name, bool isAvailable, int yearOfManufacture, string description, string whyNotAvailable, int batteryLife, bool hasAutoFocus)
    {
        Camera camera;
        
        if (whyNotAvailable.Equals(""))
        {
            camera = new Camera(name, isAvailable, yearOfManufacture, description, batteryLife, hasAutoFocus);

        }
        else
        {
            camera = new Camera(name, isAvailable, yearOfManufacture, description, whyNotAvailable, batteryLife,
                hasAutoFocus);
        }
        
        Item.AvailableItems.Add(camera);
    }

    public Item GetItem(string uuid)
    {
        Item searchedItem;
        
        searchedItem = Item.AvailableItems.Find(i => i.Uuid == uuid) 
                        ?? throw new ArgumentNullException("Could not find item in item list");
        
        return searchedItem;
    }

    public void RemoveItem(string uuid)
    {
        Item.AvailableItems.Remove(GetItem(uuid));
    }

    public List<Item> GetAllItems()
    {
        List<Item> allItems = new List<Item>();
        
        allItems.AddRange(Item.AvailableItems);
        allItems.AddRange(ItemRental.RentedItems.Select(r => r.Item));
        allItems.AddRange(Servicing.ItemsInService.Select(r => r.Item));
        
        return allItems;
    }

    public List<Item> GetAvailableItems()
    {
        List<Item> allItems = new List<Item>();
        
        allItems.AddRange(Item.AvailableItems);
        
        return allItems;
    }
}
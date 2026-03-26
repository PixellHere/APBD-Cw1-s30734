using APBD_Cw1_s30734.Models;

namespace APBD_Cw1_s30734.Service;

public class ServicingService
{

    public ServicingService()
    {
    }

    public void SendItemToService(string itemUuid, User fixer, DateTime startDate,
        DateTime expectedEndDate, string faultDescription)
    {
        Item item = Item.AvailableItems.Find(i => i.Uuid == itemUuid)
                    ?? throw new ArgumentNullException("Could not find item in item list");
        
        if (item.IsAvailable)
        {
            Servicing service = new Servicing(item, fixer, startDate, expectedEndDate, faultDescription);
            Servicing.ItemsInService.Add(service);
            item.IsAvailable = false;
            Item.AvailableItems.Remove(item);
        }
        else
        {
            throw new ArgumentException("Item is not available");
        }
    }

    public void ChangeExpectedEndDate(string itemUuid,DateTime expectedEndDate, String? addExplanation)
    {
        Servicing service = Servicing.ItemsInService.Find(servicing => servicing.Item.Uuid.Equals(itemUuid))
                            ?? throw new ArgumentNullException("Could not find item in serviving items");
        
        service.ExpectedEndDate = expectedEndDate;
        service.FaultDescription = service.FaultDescription + "\n" + addExplanation;
    }

    public void MarkAsRepaired(string itemUuid)
    {
        Servicing service = Servicing.ItemsInService.Find(servicing => servicing.Item.Uuid.Equals(itemUuid))
                            ?? throw new ArgumentNullException("Could not find item in serviving items");
        
        service.ExpectedEndDate = DateTime.Now;
        service.Item.IsAvailable = true;
        Item.AvailableItems.Add(service.Item);
        Servicing.ItemsInService.Remove(service);
    }

    public void UpdateFaultDescription(string itemUuid, string faultDescription)
    {
        Servicing service = Servicing.ItemsInService.Find(servicing => servicing.Item.Uuid.Equals(itemUuid))
                            ?? throw new ArgumentNullException("Could not find item in serviving items");
        
        service.FaultDescription = faultDescription;
    }
}
using APBD_Cw1_s30734.Models;

namespace APBD_Cw1_s30734.Service;

public class ItemRentalService
{

    public ItemRentalService()
    {
    }

    public void RentItem(User renter, Item item, DateTime startDate, DateTime endDate)
    {
        if (item.IsAvailable)
        {
            ItemRental itemRental = new ItemRental(renter, item, startDate, endDate);
        
            item.IsAvailable = false;
            Item.AvailableItems.Remove(item);
        
            ItemRental.RentedItems.Add(itemRental);
        }
        else
        {
            throw new ArgumentException("Item is not available");
        }
    }
    
    public void ReturnItem(string itemUuid)
    {
        Item item = Item.AvailableItems.Find(item => item.Uuid == itemUuid) 
                          ?? throw new ArgumentNullException("Could not find item uuid") ;

        if (item.IsAvailable)
        {
            throw new ArgumentException("Item is not rented");
        }
        
        ItemRental itemRental = ItemRental.RentedItems.Find(rental => rental.Item == item)
                                ?? throw new ArgumentNullException("Could not find item in rented items") ;
        
        itemRental.IsReturned = true;

        if (itemRental.EndDate < DateTime.Now)
        {
            itemRental.DelayCost = CalculateDelayCost(DateTime.Now.Subtract(itemRental.EndDate).Days);
            
        }
        else
        {
            itemRental.RentCost = 0;
            itemRental.EndDate = DateTime.Now;
        }
        
        item.IsAvailable = true;
        Item.AvailableItems.Add(item);
    }

    private double CalculateDelayCost(int delay)
    {
        int delayWeeks = delay / 7;
        int delayDays = delay % 7;
        double delayCost;
        
        if (delayWeeks > 0)
        {
            delayCost = delayWeeks * ItemRental.DelayCosts[7] +  (delayDays > 0 ? ItemRental.DelayCosts[delayDays] : 0);
        }
        else
        {
            delayCost = delayDays > 0 ? ItemRental.DelayCosts[delayDays] : 0;
        }
        
        return delayCost;
    }

    public bool ReturnedOnTime(string itemUuid)
    {
        Item item = Item.AvailableItems.Find(item => item.Uuid == itemUuid) 
                    ?? throw new ArgumentNullException("Could not find item uuid") ;
        
        ItemRental itemRental = ItemRental.RentedItems.Find(rental => rental.Item == item)
                                ?? throw new ArgumentNullException("Could not find item in rented items") ;

        if (itemRental.DelayCost == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
using APBD_Cw1_s30734.Models;

namespace APBD_Cw1_s30734.Service;

public class ItemRentalService
{
    public void RentItem(string renterUuid, string itemUuid, DateTime startDate, DateTime endDate)
    {
        User renter = User.Users.Find(user => user.Uuid == renterUuid)
                      ?? throw new ArgumentNullException("Could not find user");
        
        Item item = Item.AvailableItems.Find(item => item.Uuid == itemUuid)
                    ?? throw new ArgumentNullException("Could not find item");
        
        if (item.IsAvailable && UserCanRent(renter))
        {
            
            ItemRental itemRental = new ItemRental(renter, item, startDate, endDate);
        
            item.IsAvailable = false;
            Item.AvailableItems.Remove(item);
        
            ItemRental.RentedItems.Add(itemRental);
        }
        else
        {
            throw new ArgumentException("Item is not available or User cannot rent");
        }
    }

    private bool UserCanRent(User user)
    {
        int limit = (user.UserType == UserType.Employee) ? Employee.MaxActiveRentals : Student.MaxActiveRentals;
        
        int activeUserRentals = ItemRental.RentedItems.FindAll(rental => rental.Renter.Uuid.Equals(user.Uuid)).Count;
        
        return activeUserRentals < limit;
    }
    
    public void ReturnItem(string itemUuid)
    {
        Item item = Item.AvailableItems.Find(item => item.Uuid.Equals(itemUuid));

        if (item != null)
        {
            throw new ArgumentException("Item is not rented");
        }
        
        ItemRental itemRental = ItemRental.RentedItems.Find(rental => rental.Item.Uuid.Equals(itemUuid))
                                ?? throw new ArgumentNullException("Could not find item in rented items") ;
        
        item = itemRental.Item;
        
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
        ItemRental itemRental = ItemRental.RentedItems.Find(rental => rental.Item.Uuid.Equals(itemUuid))
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

    public List<ItemRental> GetUserRentals(string userUuid)
    {
        var userRentals = ItemRental.RentedItems.FindAll(rental => rental.Renter.Uuid.Equals(userUuid));
        
        return userRentals;
    }

    public List<ItemRental> GetDelayedRentals(bool onlyActive)
    {
        List<ItemRental> delayedRentals = new List<ItemRental>();

        if (onlyActive)
        {
            delayedRentals = ItemRental.RentedItems.FindAll(rental => rental.IsReturned == false && rental.EndDate < DateTime.Now);
        }
        else
        {
            delayedRentals = ItemRental.RentedItems.FindAll(rental => rental.DelayCost > 0 || (rental.EndDate < DateTime.Now && rental.IsReturned == false));
        }
        
        return delayedRentals;
    }
    
    public void showRentalReport()
    {
        Console.WriteLine("======= Rental Report =======");
        Console.WriteLine("All rentals: " +  ItemRental.RentedItems.Count);
        Console.WriteLine("Finished rentals: " +  ItemRental.RentedItems.FindAll(rental => rental.IsReturned).Count);
        Console.WriteLine("Pending rentals: " +  ItemRental.RentedItems.FindAll(rental => rental.IsReturned == false).Count);
        Console.WriteLine("Delayed returns: " + GetDelayedRentals(false).Count);
        
        Console.WriteLine("");
        Console.WriteLine("All available items: " +  Item.AvailableItems.Count);
        Console.WriteLine("Available laptops: " + Item.AvailableItems.OfType<Laptop>().Count());
        Console.WriteLine("Available projectors: " + Item.AvailableItems.OfType<Projector>().Count());
        Console.WriteLine("Available cameras: " + Item.AvailableItems.OfType<Camera>().Count());
        
        Console.WriteLine("");
        Console.WriteLine("Items in service: " + Servicing.ItemsInService.Count);
    }
}
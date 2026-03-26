using System;
using APBD_Cw1_s30734.Models;
using APBD_Cw1_s30734.Service;

namespace APBD_Cw1_s30734
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create services
            var itemService = new ItemService();
            var rentalService = new ItemRentalService();
            ServicingService servicingService = new ServicingService();

            // 1. Adding items
            itemService.AddLaptopToInventory("Asus 1", true, 2020, "The best laptop", "", "Windows", "x86");
            itemService.AddLaptopToInventory("Dell 1", true, 2026, "The worst laptop", "", "Windows", "ARM");
            itemService.AddCameraToInventory("Canon EOS", true, 2022, "Professional camera", "", 10, true);
            itemService.AddProjectorToInventory("Sony x420",  true, 2020, "Great projector", "","4K", true);
            
            // 2. Adding users
            var student = new Student("Jan", "Kowalski", 2, "Informatyka");
            User.Users.Add(student);
            var employee = new Employee("Anna", "Nowak", "Profesor", 8000);
            User.Users.Add(employee);

            // 3. Correct rentals
            var laptop1 = Item.AvailableItems.Find(item => item.Name.Equals("Asus 1"))?.Uuid;
            var laptop2 = Item.AvailableItems.Find(item => item.Name.Equals("Dell 1"))?.Uuid;
            rentalService.RentItem(student.Uuid, laptop1, new DateTime(2026,3,20), new DateTime(2026,3,22));
            rentalService.RentItem(employee.Uuid, laptop2, DateTime.Now, DateTime.Now.AddDays(7));

            // 4. Exceed rental limit
            try
            {
                // student already has 1 active rental, rent 2nd
                var camera1 = Item.AvailableItems.Find(item => item.Name.Equals("Canon EOS"))?.Uuid;
                rentalService.RentItem(student.Uuid, camera1, DateTime.Now, DateTime.Now.AddDays(3));
                
                // attempt 3rd rental – should fail
                var projector1 = Item.AvailableItems.Find(item => item.Name.Equals("Sony x420"))?.Uuid;
                rentalService.RentItem(student.Uuid, projector1, DateTime.Now, DateTime.Now.AddDays(3));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Expected limit error: {ex.Message}");
            }

            // 5. Attempt to rent serviced item
            var itemToService = Item.AvailableItems.Find(item => item.Name.Equals("Sony x420"))?.Uuid;
            servicingService.SendItemToService(itemToService,employee,DateTime.Now,DateTime.Now.AddDays(7),"Damaged power cable");
            
            try
            {
                rentalService.RentItem(student.Uuid, itemToService, DateTime.Now, DateTime.Now.AddDays(2));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Expected damaged item error: {ex.Message}");
            }

            // 6. Return on time
            rentalService.ReturnItem(laptop2);

            // 7. Late return
            itemService.AddLaptopToInventory("MacBook Air", true, 2023, "Late laptop", "", "MacOS", "ARM");
            var lateItem = Item.AvailableItems.Find(item => item.Name.Equals("MacBook Air"))?.Uuid;
            rentalService.RentItem(employee.Uuid, lateItem, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-5));
            rentalService.ReturnItem(lateItem);

            // 8. Final report
            rentalService.showRentalReport();
        }
    }
}

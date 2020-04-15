using GUI_Handin2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI_Handin2.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>())) //serviceProvider.GetRequiredService<DbContextOptions<DbContext>>())
            {
                if (context.Guests.Any())
                {
                    System.Console.WriteLine("Data already exists - not seeding");
                    return;
                }



                Room room1 = new Room()
                {
                    Number = 1
                };
                context.Rooms.Add(room1);

                Room room2 = new Room()
                {
                    Number = 2
                };
                context.Rooms.Add(room2);








                Date date1 = new Date()
                {
                    Day = 1,
                    Month = 1
                };
                context.Dates.Add(date1);

                Date date2 = new Date()
                {
                    Day = 2,
                    Month = 2
                };
                context.Dates.Add(date2);



                //creating Guests
                Guest guest1 = new Guest()
                {
                    Name = "Victor Kildahl",
                    WontToEaten = true,
                    IsChild = false,
                    Room = room1,
                    Date = date1
                };
                context.Guests.Add(guest1);


                //Guest guest2 = new Guest()
                //{
                //    Name = "Lasse Mosel"
                //};
                //context.Guests.Add(guest2);

                //Guest guest3 = new Guest()
                //{
                //    Name = "Brian Stjernholm"
                //};
                //context.Guests.Add(guest3);

                //Guest guest4 = new Guest()
                //{
                //    Name = "Marc Warming"
                //};
                //context.Guests.Add(guest4);

                //Guest guest5 = new Guest()
                //{
                //    Name = "David Tegam"
                //};
                //context.Guests.Add(guest5);




                context.SaveChanges();
                System.Console.WriteLine("Data saved");
            }
        }
    }
}
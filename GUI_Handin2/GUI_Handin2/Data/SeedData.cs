﻿using GUI_Handin2.Models;
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

                Room room3 = new Room()
                {
                    Number = 3
                };
                context.Rooms.Add(room3);

                Room room4 = new Room()
                {
                    Number = 4
                };
                context.Rooms.Add(room4);

                Room room5 = new Room()
                {
                    Number = 5
                };
                context.Rooms.Add(room5);





                //creating Guests
                Guest guest1 = new Guest()
                {
                    Name = "Victor Kildahl",
                    WontToEaten = true,
                    IsChild = false,
                    GuestDate = "01/01",
                    Room = room1
                };
                context.Guests.Add(guest1);


                Guest guest2 = new Guest()
                {
                    Name = "Lasse Mosel",
                    WontToEaten = true,
                    IsChild = false,
                    GuestDate = "21/03",
                    Room = room1
                };
                context.Guests.Add(guest2);

                Guest guest3 = new Guest()
                {
                    Name = "Brian Stjernholm",
                    WontToEaten = true,
                    IsChild = true,
                    GuestDate = "03/12",
                    Room = room2
                };
                context.Guests.Add(guest3);

                Guest guest4 = new Guest()
                {
                    Name = "Marc Warming",
                    WontToEaten = false,
                    IsChild = true,
                    GuestDate = "11/16",
                    Room = room2
                };
                context.Guests.Add(guest4);

                Guest guest5 = new Guest()
                {
                    Name = "David Tegam",
                    WontToEaten = true,
                    IsChild = false,
                    GuestDate = "07/11",
                    Room = room3
                };
                context.Guests.Add(guest5);




                context.SaveChanges();
                System.Console.WriteLine("Data saved");
            }
        }
    }
}
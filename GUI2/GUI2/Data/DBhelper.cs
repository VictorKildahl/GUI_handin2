using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GUI2.Data;
using GUI2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GUI2.Data
{
    public static class DbHelper
    {
        public static void SeedData(ApplicationDbContext db, UserManager<Users> userManager, ILogger log)
        {
            SeedUsers(userManager, log);
        }

        public static void SeedUsers(UserManager<Users> userManager, ILogger log)
        {
            const string waiterEmail = "waiter@gmail.com";
            const string waiterPassword = "Waiter123!";

            if (userManager.FindByNameAsync(waiterEmail).Result == null)
            {
                log.LogWarning("Seeding the waiter user");
                var user = new Users
                {
                    UserName = waiterEmail,
                    Email = waiterEmail
                };
                IdentityResult result = userManager.CreateAsync
                    (user, waiterPassword).Result;
                if (result.Succeeded)
                {
                    var waiterClaim = new Claim("Waiter", "Yes");
                    userManager.AddClaimAsync(user, waiterClaim);
                }
            }

            const string kitchenEmail = "kitchen@gmail.com";
            const string kitchenPassword = "Kitchen123!";

            if (userManager.FindByNameAsync(kitchenEmail).Result == null)
            {
                log.LogWarning("Seeding the kitchen user");
                var user = new Users
                {
                    UserName = kitchenEmail,
                    Email = kitchenEmail
                };
                IdentityResult result = userManager.CreateAsync
                    (user, kitchenPassword).Result;
                if (result.Succeeded)
                {
                    var kitchenClaim = new Claim("Kitchen", "Yes");
                    userManager.AddClaimAsync(user, kitchenClaim);
                }
            }


            //public static void Initialize(IServiceProvider serviceProvider)
            //{


            //        //using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            //        //{
            //        //    // Look for any movies.
            //        //    if (context.Users.Any())
            //        //    {
            //        //        return;   // DB has been seeded
            //        //    }

            //        //    context.Users.AddRange(new Users
            //        //    {
            //        //        FirstName = "David",
            //        //        LastName = "Tegam",
            //        //        Email = "dt@gmail.com",
            //        //        PasswordHash = "123456",
            //        //        UserName = "dt@gmail.com",


            //        //    }


            //        //    );
            //        //    context.SaveChanges();
            //        //}
            //    }
        }
    }
}

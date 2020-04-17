using System;
using System.Collections.Generic;
using System.Text;
using GUI2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GUI2.Data
{
    public class ApplicationDbContext : IdentityDbContext<Users>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CheckIn> CheckIns { get; set; }

        public DbSet<Breakfast> Breakfasts { get; set; }

        public DbSet<GUI2.Models.ViewModels.ReceptionInfoViewModel> ReceptionInfoViewModels { get; set; }

    }
}

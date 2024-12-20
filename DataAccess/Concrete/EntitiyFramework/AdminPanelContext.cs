﻿using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class AdminPanelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer(@"Server =(localdb)\ZEHRA; Database=AdminDatabase; Trusted_Connection=true");
            //optionsBuilder.UseInMemoryDatabase("RentACar");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

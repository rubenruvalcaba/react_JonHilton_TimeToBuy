﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeToBuy.Domain
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)  {}
        public DbSet<Product> Products {get;set;}
        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        public DbSet<Order> Orders { get; set; }


    }
}

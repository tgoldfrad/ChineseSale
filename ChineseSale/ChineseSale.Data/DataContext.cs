using ChineseSale.Core.Entities;
using ChineseSale.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace ChineseSale.Data
{
    
    public class DataContext:DbContext
    {
        
        public DbSet<Donor> DonorsList { get; set; }
        public DbSet<Product> ProductsList { get; set; }
        public DbSet<Order> OrdersList { get; set; }
        public DbSet<OrderDetails> OrderDetailsList { get; set; }
        public DbSet<City> CitiesList { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.LogTo(mesege => Console.Write(mesege));
        //}
    }


}

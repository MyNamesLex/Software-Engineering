﻿using ASP.NET_Core_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemClient>().HasKey(ic => new
            {
                ic.ItemId,
                ic.ClientId
            });

            modelBuilder.Entity<ItemClient>().HasOne(i => i.Item).WithMany(ic=>ic.ItemClients).HasForeignKey(i => i.ItemId);
            modelBuilder.Entity<ItemClient>().HasOne(c => c.Client).WithMany(ic => ic.ItemClients).HasForeignKey(c => c.ClientId);

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                Id=4,
                Name="Microphone",
                Price=40,
                SerialNumberId=10,
                },
                new Item
                {
                    Id = 5,
                    Name = "Desktop",
                    Price = 400,
                    SerialNumberId = 20,
                }
                );
            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber
                {
                    Id = 10,
                    Name = "MIC150",
                    ItemId=4,
                }
                );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronics"
                },
                  new Category
                  {
                      Id = 2,
                      Name = "Books"
                  }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ItemClient> ItemClients { get; set; }
    }
}

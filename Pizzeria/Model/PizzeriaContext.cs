using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pizzeria.Model
{
    public class PizzeriaContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Cook> Cooks { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public PizzeriaContext()
        {

        }

        public PizzeriaContext(DbContextOptions<PizzeriaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasDiscriminator<int>("PersonType")
                .HasValue<Client>(1)
                .HasValue<Cook>(2);

            modelBuilder.Entity<Client>()
                .HasData(new Client() {
                    Id = 1,
                    Name = "Taras",
                    Surname = "Kulyavets",
                    Email = "client@pizzeria",
                    Password = "123456"
                });

            modelBuilder.Entity<Cook>()
                .HasData(new Cook()
                {
                    Id = 2,
                    Name = "Sebastian",
                    Surname = "Kachniarz",
                    Email = "cook@pizzeria",
                    Password = "123456"
                });

            modelBuilder.Entity<Dish>()
                .HasData(new List<Dish>()
                {
                    new Dish()
                    {
                        Id = 1,
                        Name = "Pizza Caprichosa",
                        Price = 5.99
                    },
                    new Dish()
                    {
                        Id = 2,
                        Name = "Pizza Margarita",
                        Price = 6.99
                    },
                    new Dish()
                    {
                        Id = 3,
                        Name = "Pizza Two Cheese",
                        Price = 8.99
                    },
                    new Dish()
                    {
                        Id = 4,
                        Name = "Pizza California",
                        Price = 12.99
                    },
                    new Dish()
                    {
                        Id = 5,
                        Name = "Pizza Montanara",
                        Price = 5.49
                    },
                    new Dish()
                    {
                        Id = 6,
                        Name = "Pizza al Pesto",
                        Price = 6.49
                    },
                    new Dish()
                    {
                        Id = 7,
                        Name = "Pizza Francescana",
                        Price = 7.29
                    },
                    new Dish()
                    {
                        Id = 8,
                        Name = "Pizza Caprese",
                        Price = 10.99
                    },
                    new Dish()
                    {
                        Id = 9,
                        Name = "Pizza Marinara",
                        Price = 9.99
                    },
                    new Dish()
                    {
                        Id = 10,
                        Name = "Pizza Fattoria",
                        Price = 3.99
                    },
                    new Dish()
                    {
                        Id = 11,
                        Name = "Pizza Ortolana",
                        Price = 7.99
                    },
                    new Dish()
                    {
                        Id = 12,
                        Name = "Pizza Contadina",
                        Price = 5.59
                    }
                });

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderItems)
                .WithOne(e => e.Order)
                .HasForeignKey(e => e.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(e => e.Dish)
                .WithMany(e => e.OrderItems)
                .HasForeignKey(e => e.DishId);
        }
    }
}

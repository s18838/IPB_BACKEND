﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pizzeria.Model;

namespace Pizzeria.Migrations
{
    [DbContext(typeof(PizzeriaContext))]
    partial class PizzeriaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("Pizzeria.Model.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Dishes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pizza Caprichosa",
                            Price = 5.9900000000000002
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pizza Margarita",
                            Price = 6.9900000000000002
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pizza Two Cheese",
                            Price = 8.9900000000000002
                        },
                        new
                        {
                            Id = 4,
                            Name = "Pizza California",
                            Price = 12.99
                        },
                        new
                        {
                            Id = 5,
                            Name = "Pizza Montanara",
                            Price = 5.4900000000000002
                        },
                        new
                        {
                            Id = 6,
                            Name = "Pizza al Pesto",
                            Price = 6.4900000000000002
                        },
                        new
                        {
                            Id = 7,
                            Name = "Pizza Francescana",
                            Price = 7.29
                        },
                        new
                        {
                            Id = 8,
                            Name = "Pizza Caprese",
                            Price = 10.99
                        },
                        new
                        {
                            Id = 9,
                            Name = "Pizza Marinara",
                            Price = 9.9900000000000002
                        },
                        new
                        {
                            Id = 10,
                            Name = "Pizza Fattoria",
                            Price = 3.9900000000000002
                        },
                        new
                        {
                            Id = 11,
                            Name = "Pizza Ortolana",
                            Price = 7.9900000000000002
                        },
                        new
                        {
                            Id = 12,
                            Name = "Pizza Contadina",
                            Price = 5.5899999999999999
                        });
                });

            modelBuilder.Entity("Pizzeria.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Pizzeria.Model.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DishId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Pizzeria.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasDiscriminator<int>("PersonType");
                });

            modelBuilder.Entity("Pizzeria.Model.Client", b =>
                {
                    b.HasBaseType("Pizzeria.Model.Person");

                    b.HasDiscriminator().HasValue(1);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "client@pizzeria",
                            Name = "Taras",
                            Password = "123456",
                            Surname = "Kulyavets"
                        });
                });

            modelBuilder.Entity("Pizzeria.Model.Cook", b =>
                {
                    b.HasBaseType("Pizzeria.Model.Person");

                    b.HasDiscriminator().HasValue(2);

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Email = "cook@pizzeria",
                            Name = "Sebastian",
                            Password = "123456",
                            Surname = "Kachniarz"
                        });
                });

            modelBuilder.Entity("Pizzeria.Model.Order", b =>
                {
                    b.HasOne("Pizzeria.Model.Person", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Pizzeria.Model.OrderItem", b =>
                {
                    b.HasOne("Pizzeria.Model.Dish", "Dish")
                        .WithMany("OrderItems")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pizzeria.Model.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Pizzeria.Model.Dish", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Pizzeria.Model.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}

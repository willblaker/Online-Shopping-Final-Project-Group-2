﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Online_Shopping_Final_Project.Data;

#nullable disable

namespace OnlineShoppingFinalProject.Migrations
{
    [DbContext(typeof(ShoppingContext))]
    [Migration("20240418170516_OrderDetails")]
    partial class OrderDetails
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Online_Shopping_Final_Project.Entities.CartEntry", b =>
                {
                    b.Property<int>("CartEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartEntryId"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CartEntryId");

                    b.HasIndex("ItemId");

                    b.ToTable("CartEntry");
                });

            modelBuilder.Entity("Online_Shopping_Final_Project.Entities.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("ItemDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("ItemPrice")
                        .HasColumnType("real");

                    b.HasKey("ItemId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            ItemDescription = "Black cotton crew neck T-shirt for Men",
                            ItemName = "Mens - Black T-shirt",
                            ItemPrice = 15.5f
                        },
                        new
                        {
                            ItemId = 2,
                            ItemDescription = "Green cotton crew neck T-shirt for Men",
                            ItemName = "Mens - Green T-shirt",
                            ItemPrice = 15.25f
                        },
                        new
                        {
                            ItemId = 3,
                            ItemDescription = "Pink cotton crew neck T-shirt for Men",
                            ItemName = "Mens - Pink T-shirt",
                            ItemPrice = 14.5f
                        },
                        new
                        {
                            ItemId = 4,
                            ItemDescription = "Biege cotton crew neck T-shirt for Men",
                            ItemName = "Mens - Biege T-shirt",
                            ItemPrice = 13f
                        },
                        new
                        {
                            ItemId = 5,
                            ItemDescription = "Light Blue Denim Jeans for Men",
                            ItemName = "Mens - Light Blue Jeans",
                            ItemPrice = 22.25f
                        },
                        new
                        {
                            ItemId = 6,
                            ItemDescription = "Black Denim Jeans for Men",
                            ItemName = "Mens - Black Jeans",
                            ItemPrice = 25.5f
                        },
                        new
                        {
                            ItemId = 7,
                            ItemDescription = "Grey Denim Jeans for Men",
                            ItemName = "Mens - Grey Jeans",
                            ItemPrice = 27.25f
                        },
                        new
                        {
                            ItemId = 8,
                            ItemDescription = "Grey Denim Jeans for Men",
                            ItemName = "Mens - Blue Jeans",
                            ItemPrice = 30f
                        });
                });

            modelBuilder.Entity("Online_Shopping_Final_Project.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("OrderHistory");
                });

            modelBuilder.Entity("Online_Shopping_Final_Project.Entities.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Online_Shopping_Final_Project.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Address = "123 User1 St",
                            City = "City1",
                            Email = "user1@onlineshopping.com",
                            FirstName = "User",
                            LastName = "User1",
                            PasswordHash = "hashedpassword1",
                            PostalCode = "45219",
                            State = "State1",
                            Username = "user 1"
                        },
                        new
                        {
                            UserId = 2,
                            Address = "123 User2 St",
                            City = "City2",
                            Email = "user2@onlineshopping.com",
                            FirstName = "User",
                            LastName = "User2",
                            PasswordHash = "hashedpassword2",
                            PostalCode = "45219",
                            State = "State2",
                            Username = "user 2"
                        },
                        new
                        {
                            UserId = 3,
                            Address = "123 User3 St",
                            City = "City3",
                            Email = "user3@onlineshopping.com",
                            FirstName = "User",
                            LastName = "User3",
                            PasswordHash = "hashedpassword3",
                            PostalCode = "45219",
                            State = "State3",
                            Username = "user 3"
                        });
                });

            modelBuilder.Entity("Online_Shopping_Final_Project.Entities.CartEntry", b =>
                {
                    b.HasOne("Online_Shopping_Final_Project.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Online_Shopping_Final_Project.Entities.Order", b =>
                {
                    b.HasOne("Online_Shopping_Final_Project.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Online_Shopping_Final_Project.Entities.OrderDetail", b =>
                {
                    b.HasOne("Online_Shopping_Final_Project.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online_Shopping_Final_Project.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Online_Shopping_Final_Project.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}

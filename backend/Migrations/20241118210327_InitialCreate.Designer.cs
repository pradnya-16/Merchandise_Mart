﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241118210327_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -2,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -3,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -4,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -5,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -6,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -7,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -8,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -9,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -10,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -11,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -12,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -13,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -14,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -15,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -16,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -17,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -18,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -19,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -20,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -21,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -22,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -23,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -24,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        },
                        new
                        {
                            Id = -25,
                            ImageUrl = "",
                            Name = "",
                            Price = 0m
                        });
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OrderItem", b =>
                {
                    b.HasOne("Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}

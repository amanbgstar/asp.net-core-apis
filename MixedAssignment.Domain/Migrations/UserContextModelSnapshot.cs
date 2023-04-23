﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MixedAssignment.Domain.Context;

#nullable disable

namespace MixedAssignment.Domain.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MixedAssignment.Domain.Models.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CardId"), 1L, 1);

                    b.Property<int>("CVV")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<long>("CardNumber")
                        .HasMaxLength(16)
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CardId");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("MixedAssignment.Domain.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("MixedAssignment.Domain.Models.CartDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("MixedAssignment.Domain.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"), 1L, 1);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            CountryName = "India"
                        },
                        new
                        {
                            CountryId = 2,
                            CountryName = "Pakistan"
                        },
                        new
                        {
                            CountryId = 3,
                            CountryName = "china"
                        },
                        new
                        {
                            CountryId = 4,
                            CountryName = "United States"
                        },
                        new
                        {
                            CountryId = 5,
                            CountryName = "Russia"
                        });
                });

            modelBuilder.Entity("MixedAssignment.Domain.Models.OTP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("GenDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Otp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("otp");
                });

            modelBuilder.Entity("MixedAssignment.Domain.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("ProductImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("PurchasePrice")
                        .HasColumnType("real");

                    b.Property<DateTime>("SellingDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("SellingPrice")
                        .HasColumnType("real");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("userid");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MixedAssignment.Domain.Models.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateId"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("StateId");

                    b.HasIndex("CountryId");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            StateId = 1,
                            CountryId = 1,
                            StateName = "Andhra Pradesh"
                        },
                        new
                        {
                            StateId = 2,
                            CountryId = 1,
                            StateName = "Arunachal Pradesh"
                        },
                        new
                        {
                            StateId = 3,
                            CountryId = 1,
                            StateName = "Assam"
                        },
                        new
                        {
                            StateId = 4,
                            CountryId = 1,
                            StateName = "Bihar"
                        },
                        new
                        {
                            StateId = 5,
                            CountryId = 1,
                            StateName = "Chhattisgarh"
                        },
                        new
                        {
                            StateId = 6,
                            CountryId = 1,
                            StateName = "Goa"
                        },
                        new
                        {
                            StateId = 7,
                            CountryId = 1,
                            StateName = "Gujarat"
                        },
                        new
                        {
                            StateId = 8,
                            CountryId = 1,
                            StateName = "Himachal Pradesh"
                        },
                        new
                        {
                            StateId = 9,
                            CountryId = 1,
                            StateName = "Jharkhand"
                        },
                        new
                        {
                            StateId = 10,
                            CountryId = 1,
                            StateName = "Karnataka"
                        },
                        new
                        {
                            StateId = 11,
                            CountryId = 1,
                            StateName = "Kerala"
                        },
                        new
                        {
                            StateId = 12,
                            CountryId = 1,
                            StateName = "Madhya Pradesh"
                        },
                        new
                        {
                            StateId = 13,
                            CountryId = 1,
                            StateName = "Maharashtra"
                        },
                        new
                        {
                            StateId = 14,
                            CountryId = 1,
                            StateName = "Manipur"
                        },
                        new
                        {
                            StateId = 15,
                            CountryId = 1,
                            StateName = "Meghalaya"
                        },
                        new
                        {
                            StateId = 16,
                            CountryId = 1,
                            StateName = "Mizoram"
                        },
                        new
                        {
                            StateId = 17,
                            CountryId = 1,
                            StateName = "Nagaland"
                        },
                        new
                        {
                            StateId = 18,
                            CountryId = 1,
                            StateName = "Odisha"
                        },
                        new
                        {
                            StateId = 19,
                            CountryId = 1,
                            StateName = "Punjab"
                        },
                        new
                        {
                            StateId = 20,
                            CountryId = 1,
                            StateName = "Rajasthan"
                        },
                        new
                        {
                            StateId = 21,
                            CountryId = 1,
                            StateName = "Sikkim"
                        },
                        new
                        {
                            StateId = 22,
                            CountryId = 1,
                            StateName = "Tamil Nadu"
                        },
                        new
                        {
                            StateId = 23,
                            CountryId = 1,
                            StateName = "Telangana"
                        },
                        new
                        {
                            StateId = 24,
                            CountryId = 1,
                            StateName = "Tripura"
                        },
                        new
                        {
                            StateId = 25,
                            CountryId = 1,
                            StateName = "Uttar Pradesh"
                        },
                        new
                        {
                            StateId = 26,
                            CountryId = 1,
                            StateName = "Uttarakhand"
                        },
                        new
                        {
                            StateId = 27,
                            CountryId = 1,
                            StateName = "West Bengal"
                        },
                        new
                        {
                            StateId = 28,
                            CountryId = 2,
                            StateName = "Balochistan"
                        },
                        new
                        {
                            StateId = 29,
                            CountryId = 2,
                            StateName = "Sindh"
                        },
                        new
                        {
                            StateId = 30,
                            CountryId = 3,
                            StateName = "Henan"
                        },
                        new
                        {
                            StateId = 31,
                            CountryId = 3,
                            StateName = "Fujian"
                        },
                        new
                        {
                            StateId = 32,
                            CountryId = 3,
                            StateName = "Hainan"
                        },
                        new
                        {
                            StateId = 33,
                            CountryId = 4,
                            StateName = "California"
                        },
                        new
                        {
                            StateId = 34,
                            CountryId = 4,
                            StateName = "Texas"
                        },
                        new
                        {
                            StateId = 35,
                            CountryId = 4,
                            StateName = "Washington"
                        },
                        new
                        {
                            StateId = 36,
                            CountryId = 5,
                            StateName = "Adygea"
                        },
                        new
                        {
                            StateId = 37,
                            CountryId = 5,
                            StateName = "Altai"
                        },
                        new
                        {
                            StateId = 38,
                            CountryId = 5,
                            StateName = "Bashkortostan"
                        });
                });

            modelBuilder.Entity("MixedAssignment.Domain.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Zipcode")
                        .HasMaxLength(6)
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("CountryId");

                    b.HasIndex("StateId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MixedAssignment.Domain.Models.UserType", b =>
                {
                    b.Property<int>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserTypeId"), 1L, 1);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("UserTypeId");

                    b.ToTable("UserTypes");

                    b.HasData(
                        new
                        {
                            UserTypeId = 1,
                            Role = "Admin"
                        },
                        new
                        {
                            UserTypeId = 2,
                            Role = "Customer"
                        });
                });

            modelBuilder.Entity("MixedAssignment.Domain.Models.Card", b =>
                {
                    b.HasOne("MixedAssignment.Domain.Models.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MixedAssignment.Domain.Models.Cart", b =>
                {
                    b.HasOne("MixedAssignment.Domain.Models.User", "User")
                        .WithMany("Carts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MixedAssignment.Domain.Models.CartDetail", b =>
                {
                    b.HasOne("MixedAssignment.Domain.Models.Cart", "Cart")
                        .WithMany("cartDetails")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("MixedAssignment.Domain.Models.Product", b =>
                {
                    b.HasOne("MixedAssignment.Domain.Models.User", "user")
                        .WithMany("Products")
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("MixedAssignment.Domain.Models.State", b =>
                {
                    b.HasOne("MixedAssignment.Domain.Models.Country", "Country")
                        .WithMany("State")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("MixedAssignment.Domain.Models.User", b =>
                {
                    b.HasOne("MixedAssignment.Domain.Models.Country", "Country")
                        .WithMany("User")
                        .HasForeignKey("CountryId");

                    b.HasOne("MixedAssignment.Domain.Models.State", "States")
                        .WithMany("User")
                        .HasForeignKey("StateId");

                    b.HasOne("MixedAssignment.Domain.Models.UserType", "UserTypes")
                        .WithMany("User")
                        .HasForeignKey("UserTypeId");

                    b.Navigation("Country");

                    b.Navigation("States");

                    b.Navigation("UserTypes");
                });

            modelBuilder.Entity("MixedAssignment.Domain.Models.Cart", b =>
                {
                    b.Navigation("cartDetails");
                });

            modelBuilder.Entity("MixedAssignment.Domain.Models.Country", b =>
                {
                    b.Navigation("State");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MixedAssignment.Domain.Models.State", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("MixedAssignment.Domain.Models.User", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("Carts");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("MixedAssignment.Domain.Models.UserType", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}

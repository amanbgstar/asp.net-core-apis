using Microsoft.EntityFrameworkCore;
using MixedAssignment.Domain.Models;
using MixedAssignment.Domain.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Domain.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<OTP> otp { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.HasKey(x => x.UserId);
                builder.Property(x => x.UserId).UseIdentityColumn();
                builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
                builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
                builder.Property(x => x.Email).IsRequired();
                builder.Property(x => x.DOB).IsRequired();
                builder.Property(x => x.Username).IsRequired();
                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.Mobile).HasMaxLength(10).IsRequired();
                builder.Property(x => x.Address).IsRequired();
                builder.Property(x => x.Zipcode).HasMaxLength(6);
                builder.Property(x => x.ProfileImage).IsRequired(false);
                
            });

            modelBuilder.Entity<UserType>(builder =>
            {
                builder.HasKey(x => x.UserTypeId);
                builder.Property(x => x.Role).HasMaxLength(10);

                builder.HasMany<User>(x => x.User)
                .WithOne(x => x.UserTypes)
                .HasForeignKey(x => x.UserTypeId)
                .IsRequired(false);
            });

            modelBuilder.Entity<Country>(builder =>
            {
                builder.HasKey(x => x.CountryId);
                builder.Property(x => x.CountryName).HasMaxLength(50);

                builder.HasMany<State>(x => x.State)
                .WithOne(x => x.Country).HasForeignKey(x => x.CountryId)
                .IsRequired(false);

                builder.HasMany<User>(x => x.User)
                .WithOne(x => x.Country).HasForeignKey(x => x.CountryId)
                .IsRequired(false);
            });

            modelBuilder.Entity<State>(builder =>
            {
                builder.HasKey(x => x.StateId);
                builder.Property(x => x.StateName).HasMaxLength(20);

                builder.HasMany<User>(x => x.User)
                .WithOne(x => x.States).HasForeignKey(x => x.StateId)
                .IsRequired(false);
            });
            
            modelBuilder.Entity<Product>(builder =>
            {
                builder.HasKey(x => x.ProductId);
                builder.Property(x => x.ProductId).UseIdentityColumn();
                builder.Property(x => x.ProductName).HasMaxLength(50).IsRequired();
                builder.Property(x => x.ProductCode).HasMaxLength(6);
                builder.Property(x => x.ProductImage).IsRequired(false);
                builder.Property(x => x.Category).HasMaxLength(50);
                builder.Property(x => x.Brand).IsRequired();
                builder.Property(x => x.PurchasePrice).IsRequired();
                builder.Property(x => x.SellingDate).IsRequired();
                builder.Property(x => x.Stock).IsRequired();

                builder.HasOne<User>(x => x.user)
                .WithMany(x => x.Products).HasForeignKey(x => x.userid)
                .IsRequired();

            });


            modelBuilder.Entity<Card>(builder =>
            {
                builder.HasKey(x => x.CardId);
                builder.Property(x => x.CardId).UseIdentityColumn();
                builder.Property(x => x.CardNumber).HasMaxLength(16).IsRequired();
                builder.Property(x => x.ExpiryDate).IsRequired();
                builder.Property(x => x.CVV).HasMaxLength(3).IsRequired();

                builder.HasOne<User>(x => x.User)
                .WithMany(x => x.Cards).HasForeignKey(x => x.UserId)
                .IsRequired();
            });

            modelBuilder.Entity<Cart>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).UseIdentityColumn();

                builder.HasOne<User>(x => x.User)
                .WithMany(x => x.Carts).HasForeignKey(x => x.UserId)
                .IsRequired();
            });

            modelBuilder.Entity<CartDetail>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).UseIdentityColumn();
                builder.Property(x => x.CartId).IsRequired();
                builder.HasOne<Cart>(x => x.Cart)
                .WithMany(x => x.cartDetails).HasForeignKey(x => x.CartId).IsRequired();
                builder.Property(x => x.ProductId).IsRequired();
                builder.Property(x => x.Quantity).IsRequired();
            });


            modelBuilder.UserTySeed();
            modelBuilder.ContrySeed();
            modelBuilder.StatesSeed();

            modelBuilder.Entity<OTP>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).UseIdentityColumn();
            });


        }
    }

}

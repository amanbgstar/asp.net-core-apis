using Microsoft.EntityFrameworkCore;
using MixedAssignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Domain.Seeding
{
    public static class CountrySeed
    {
        public static void ContrySeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                
                new Country
                {
                    CountryId = 1,
                    CountryName = "India"
                },
                new Country
                {
                    CountryId = 2,
                    CountryName = "Pakistan"
                },
                new Country
                {
                    CountryId = 3,
                    CountryName = "china"
                },
                new Country
                {
                    CountryId = 4,
                    CountryName = "United States"
                },
                new Country
                {
                    CountryId = 5,
                    CountryName = "Russia"
                }
                );
        }
    }
}

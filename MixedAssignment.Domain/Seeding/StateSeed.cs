using Microsoft.EntityFrameworkCore;
using MixedAssignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Domain.Seeding
{
    public static class StateSeed
    {
        public static void StatesSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>().HasData(
                
                new State
                {
                    StateId = 1,
                    StateName = "Andhra Pradesh",
                    CountryId = 1
                }, new State
                {
                    StateId = 2,
                    StateName = "Arunachal Pradesh",
                    CountryId = 1
                }, new State
                {
                    StateId = 3,
                    StateName = "Assam",
                    CountryId = 1
                }, new State
                {
                    StateId = 4,
                    StateName = "Bihar",
                    CountryId = 1
                }, new State
                {
                    StateId = 5,
                    StateName = "Chhattisgarh",
                    CountryId = 1
                }, new State
                {
                    StateId = 6,
                    StateName = "Goa",
                    CountryId = 1
                }, new State
                {
                    StateId = 7,
                    StateName = "Gujarat",
                    CountryId = 1
                }, new State
                {
                    StateId = 8,
                    StateName = "Himachal Pradesh",
                    CountryId = 1
                }, new State
                {
                    StateId = 9,
                    StateName = "Jharkhand",
                    CountryId = 1
                }, new State
                {
                    StateId = 10,
                    StateName = "Karnataka",
                    CountryId = 1
                }, new State
                {
                    StateId = 11,
                    StateName = "Kerala",
                    CountryId = 1
                }, new State
                {
                    StateId = 12,
                    StateName = "Madhya Pradesh",
                    CountryId = 1
                }, new State
                {
                    StateId = 13,
                    StateName = "Maharashtra",
                    CountryId = 1
                }, new State
                {
                    StateId = 14,
                    StateName = "Manipur",
                    CountryId = 1
                }, new State
                {
                    StateId = 15,
                    StateName = "Meghalaya",
                    CountryId = 1
                }, new State
                {
                    StateId = 16,
                    StateName = "Mizoram",
                    CountryId = 1
                }, new State
                {
                    StateId = 17,
                    StateName = "Nagaland",
                    CountryId = 1
                }, new State
                {
                    StateId = 18,
                    StateName = "Odisha",
                    CountryId = 1
                }, new State
                {
                    StateId = 19,
                    StateName = "Punjab",
                    CountryId = 1
                }, new State
                {
                    StateId = 20,
                    StateName = "Rajasthan",
                    CountryId = 1
                }, new State
                {
                    StateId = 21,
                    StateName = "Sikkim",
                    CountryId = 1
                }, new State
                {
                    StateId = 22,
                    StateName = "Tamil Nadu",
                    CountryId = 1
                }, new State
                {
                    StateId = 23,
                    StateName = "Telangana",
                    CountryId = 1
                }, new State
                {
                    StateId = 24,
                    StateName = "Tripura",
                    CountryId = 1
                }, new State
                {
                    StateId = 25,
                    StateName = "Uttar Pradesh",
                    CountryId = 1
                }, new State
                {
                    StateId = 26,
                    StateName = "Uttarakhand",
                    CountryId = 1
                }, new State
                {
                    StateId = 27,
                    StateName = "West Bengal",
                    CountryId = 1
                }, new State
                {
                    StateId = 28,
                    StateName = "Balochistan",
                    CountryId = 2
                }, new State
                {
                    StateId = 29,
                    StateName = "Sindh",
                    CountryId = 2
                }, new State
                {
                    StateId = 30,
                    StateName = "Henan",
                    CountryId = 3
                }, new State
                {
                    StateId = 31,
                    StateName = "Fujian",
                    CountryId = 3
                }, new State
                {
                    StateId = 32,
                    StateName = "Hainan",
                    CountryId = 3
                }, new State
                {
                    StateId = 33,
                    StateName = "California",
                    CountryId = 4
                }, new State
                {
                    StateId = 34,
                    StateName = "Texas",
                    CountryId = 4
                }, new State
                {
                    StateId = 35,
                    StateName = "Washington",
                    CountryId = 4
                }, new State
                {
                    StateId = 36,
                    StateName = "Adygea",
                    CountryId = 5
                }, new State
                {
                    StateId = 37,
                    StateName = "Altai",
                    CountryId = 5
                }, new State
                {
                    StateId = 38,
                    StateName = "Bashkortostan",
                    CountryId = 5
                }

                );
        }

    }
}

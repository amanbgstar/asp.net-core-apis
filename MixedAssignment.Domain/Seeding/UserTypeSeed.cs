using Microsoft.EntityFrameworkCore;
using MixedAssignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Domain.Seeding
{
    public static class UserTypeSeed
    {
        public static void UserTySeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserType>().HasData(
               
                new UserType
                {
                    UserTypeId = 1,
                    Role = "Admin"
                },
                new UserType
                {
                    UserTypeId = 2,
                    Role = "Customer"
                }
                );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserTypeId { get; set; }
        public DateTime DOB { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int Zipcode { get; set; }
        public string? ProfileImage { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public UserType UserTypes { get; set; }
        public Country Country { get; set; }
        public State States { get; set; }
        public List<Product>? Products { get; set; }
        public List<Card>? Cards { get; set; }
        public List<Cart>? Carts { get; set; }
    }
}

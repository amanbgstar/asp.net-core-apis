﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.ViewModel.UserVM
{
    public class UserRegisterVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserTypeId { get; set; }
        public DateTime DOB { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int Zipcode { get; set; }
        public string ProfileImage { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
    }
}

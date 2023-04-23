using MixedAssignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Repository.UserRepo
{
    public interface IUserRepo
    {
        User AddUser(User user);
        User Login(string username);
        void AddOTP(OTP otpDet);
        User GetPassword(string email);
        User GetUserbyId(int userid);
        List<Country> GetCountries();
        List<UserType> GetRoles();
        List<State> GetStatesByCountryId();
    }
}

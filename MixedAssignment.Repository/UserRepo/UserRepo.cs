using MixedAssignment.Domain.Context;
using MixedAssignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Repository.UserRepo
{
    public class UserRepo: IUserRepo
    {
        private readonly UserContext _context;
        public UserRepo(UserContext context)
        {
            _context = context; 
        }

        //Register Method 
        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        //Login Method
        public User Login(string username)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == username);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        //Forgote password
        public User GetPassword(string email)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        //Otp save at database
        public void AddOTP (OTP otpDet)
        {
            _context.otp.Add(otpDet);
            _context.SaveChanges();
        }

        //Get userdetails by userId
        public User GetUserbyId(int userid)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == userid);
        }


        //Country Get
        public List<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        //State Gets
        public List<State> GetStatesByCountryId()
        {
            return _context.States.ToList();
        }

        //Role Get
        public List<UserType> GetRoles() 
        {
            return _context.UserTypes.ToList();
        }

    }
}

using MixedAssignment.Domain.Context;
using MixedAssignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Repository.OtpRepo
{
    public class OtpRepo: IOtpRepo
    {
        private readonly UserContext _context;
        public OtpRepo(UserContext context)
        {
            _context = context;
        }

        public OTP OtpData(int userid, string otp)
        {
            var data = _context.otp.FirstOrDefault(x => x.Otp == otp && x.Userid == userid);
            if (data == null)
            {
                return null;
            }
            return data;
        } 
    }
}

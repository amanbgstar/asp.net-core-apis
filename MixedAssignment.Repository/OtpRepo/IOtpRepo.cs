using MixedAssignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Repository.OtpRepo
{
    public interface IOtpRepo
    {
        OTP OtpData(int userid, string otp);
    }
}

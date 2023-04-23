using MixedAssignment.Domain.Models;
using MixedAssignment.Domain.Models.Response;
using MixedAssignment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Service.OtpService
{
    public interface IOtpService
    {
        void SendOTP(string RandomOtp, string no);
        OtpResponce ValidOtp(int userid, string otp);
    }
}

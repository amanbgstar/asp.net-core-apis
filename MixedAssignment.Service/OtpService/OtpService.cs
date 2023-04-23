using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MixedAssignment.Domain.Models;
using MixedAssignment.Domain.Models.Response;
using MixedAssignment.Repository.OtpRepo;
using MixedAssignment.Repository.UserRepo;
using MixedAssignment.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace MixedAssignment.Service.OtpService
{
    public class OtpService : IOtpService
    {
        private readonly IOtpRepo _otpRepo;
        private readonly IUserRepo _userRepo;
        private readonly IConfiguration _iconfiguration;

        public OtpService(IOtpRepo otpRepo, IUserRepo userRepo, IConfiguration iconfiguration)
        {
            _otpRepo = otpRepo;
            _userRepo = userRepo;
            _iconfiguration = iconfiguration;
        }

        //otp Sending 
        public void SendOTP(string Otp, string no)
        {
            var number = $"+91{no}";
            string accountSid = Environment.GetEnvironmentVariable("Sid");
            string authToken = Environment.GetEnvironmentVariable("Token");

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: $"The Otp is Valid for 10 min only {Otp}.",
                from: new Twilio.Types.PhoneNumber("+16614665915"),
                to: new Twilio.Types.PhoneNumber(number)
            );
            /*string status = message.Status.ToString();
            if(status.ToLower().ToString()== "sent".ToLower().ToString())
            {
                return "sent";
            }
            return "error";*/
        }

        //otp valid here
        public OtpResponce ValidOtp(int userid, string otp)
        {
            var role = "Customer";
            var response = new OtpResponce();
            var current_dateTime = DateTime.Now;
            var data = _otpRepo.OtpData(userid, otp);

            var user = _userRepo.GetUserbyId(userid);
            if (user.UserTypeId == 1)
            {
                role = "Admin";
            }


            if (data != null)
            {
                if (data.GenDateTime <= current_dateTime && current_dateTime <= data.ValidDateTime)
                {
                    {
                        //generate token

                        //token generate
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var tokenKey = Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]);
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                         new Claim(ClaimTypes.Name, user.FirstName +user.LastName),
                         new Claim("Id",user.UserId.ToString()),
                         new Claim(ClaimTypes.Role, role)
                            }),
                            Expires = DateTime.UtcNow.AddMinutes(20),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                        };
                        var token = tokenHandler.CreateToken(tokenDescriptor);

                        var userToken = new TokenResponse { Token = tokenHandler.WriteToken(token) };
                        response.Response = userToken.Token.ToString();
                        response.Message = user.UserId.ToString();
                        response.UserRole = user.UserTypeId;
                        response.StatusCode = 200;
                        return response;
                        /* return userToken.Token;*/
                    }
                }
            }
            return null;
        }

    }
}

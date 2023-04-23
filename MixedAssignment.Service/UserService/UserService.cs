using AutoMapper;
using MailKit;
using MixedAssignment.Domain.Models;
using MixedAssignment.Domain.Models.Mail;
using MixedAssignment.Repository.UserRepo;
using MixedAssignment.Service.Mail;
using MixedAssignment.Service.OtpService;
using MixedAssignment.ViewModel.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Service.UserService
{
    public class UserService : IUserService
    {
        private const string aesKey = "ABC123ABCCssyyfu";

        private readonly IUserRepo _userRepo;
        private readonly IOtpService _otpService;
        private readonly IMapper _mapper;
        private readonly IMailServices _mailService;

        public UserService(IUserRepo userRepo, IMapper mapper, IMailServices mailService, IOtpService otpService)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _mailService = mailService;
            _otpService = otpService;
        }


        //Method use for User Registration
        public UserRegiShowVM UserAdd(UserRegisterVM user)
        {
            var username = UsernameGenrate(user);
            var password = PasswordOrOTPGenrate(8);

            var validUser = _mapper.Map<User>(user);
            validUser.Username = EncryptString(username);
            validUser.Password = EncryptString(password);

            var retunUser = _userRepo.AddUser(validUser);

            if (retunUser == null)
            {
                return null;
            }
            retunUser.Password = password;
            retunUser.Username = username;

            var userData = new MailRequest
            {
                ToEmail = validUser.Email,
                Subject = "E-Com Credentials ",
                Body = $"Username: {validUser.Username} and Password: {validUser.Password}",
                Attachments = null
            };
            _mailService.SendEmailAsync(userData);
            
            return _mapper.Map<UserRegiShowVM>(retunUser);
        }
        //Method use for Login
        public User LogIn(string username, string password) 
        {
            username = EncryptString(username);
            password = EncryptString(password);
            var user = _userRepo.Login(username);
            if(user != null)
            {
                if (user.Password == password)
                {
                    var Otp = PasswordOrOTPGenrate(6);
                    var otpObj = new OTP
                    {
                        Otp = Otp,
                        GenDateTime = DateTime.Now,
                        ValidDateTime = DateTime.Now.AddMinutes(10),
                        Userid = user.UserId
                    };

                    _userRepo.AddOTP(otpObj);
                    _otpService.SendOTP(Otp, user.Mobile);
                    return user;
                }
            }
            return null;
        }

        //Country Get
        public List<Country> GetCountries()
        {
            return _userRepo.GetCountries();
        }

        //Roles Get
        public List<UserType> GetRoles()
        {
            return _userRepo.GetRoles();
        }

        //State List 
        public List<State> GetStatebyId()
        {
            return _userRepo.GetStatesByCountryId();
        }


        //Method for Forgot password
        public string GetPassword(string email)
        {
            var user = _userRepo.GetPassword(email);
            if (user == null)
            {
                return null;
            }
            var password = DecryptString(user.Password);
            var username = DecryptString(user.Username);
            var userData = new MailRequest
            {
                ToEmail = user.Email,
                Subject = "Password ",
                Body = $"Username: {username} and Password: {password}",
                Attachments = null
            };
            _mailService.SendEmailAsync(userData);
            return password;

        }

        //Username Genrate 
        private string UsernameGenrate(UserRegisterVM user)
        {
            var last = user.LastName;
            var fIni = user.FirstName.Substring(0, 1);
            var date = user.DOB.ToString("ddMMyy");
            return ($"EC_{last}{fIni}{date}").ToUpper();
        }

        //Pasword Genrate || Opt genrate
        private string PasswordOrOTPGenrate(int num)
        {
            const string src = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            var rStr = new StringBuilder();
            Random random = new Random();
            /*string ransRandNo = random.Next(100, 999).ToString();*/

            for (var i = 0; i < num; i++)
            {
                var c = src[random.Next(0, src.Length)];
                rStr.Append(c);
            }
            return rStr.ToString();

        }


        //Encription Code
        public string EncryptString(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(aesKey);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }


        //Decription Code 
        public string DecryptString(string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(aesKey);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }


    }
}

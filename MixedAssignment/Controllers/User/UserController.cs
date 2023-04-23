using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MixedAssignment.Domain.Models.Response;
using MixedAssignment.Service.OtpService;
using MixedAssignment.Service.UserService;
using MixedAssignment.ViewModel;
using MixedAssignment.ViewModel.OTPVM;
using MixedAssignment.ViewModel.UserVM;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MixedAssignment.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOtpService _otpService;
        private readonly IConfiguration _iconfiguration;

        public UserController(IUserService userService, IOtpService otpService, IConfiguration iconfiguration)
        {
            _userService = userService;
            _otpService = otpService;
            _iconfiguration = iconfiguration;
        }

        //Registeration 
        // api use for registration
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterVM user)
        {
            var response = new ResponseModel();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var UserAdded = _userService.UserAdd(user);
            if (UserAdded != null)
            {
                response.Message = "Sign Up success";
                response.Response = "";
                response.StatusCode = 200;
                return Ok(response);
            }
            response.Message = "Failed to Sign up";
            response.Response = "Please enter correct details";
            response.StatusCode = 400;
            return Ok(response);
        }


        //Login 
        // api use for login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginVM user)
        {
            var response = new ResponseModel();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var userDetails = _userService.LogIn(user.UserName, user.Password);
            if (userDetails == null)
            {
                response.StatusCode = 401;
                response.Response = "Enter Correct username and password";
                response.Message = "Failed";
                return Ok(response);
            }
            return Ok(userDetails);
        }

        //Forgot Password
        [HttpPost("ForgotPassword/email")]
        public async Task<IActionResult> GetPassword([FromBody] EmailForgotPassVM email)
        {
            var respose = new ResponseModel();
            if (string.IsNullOrEmpty(email.email))
            {
                return BadRequest("Plese enter your emailId");
            }
            var password = _userService.GetPassword(email.email);
            if (password == null)
            {
                respose.StatusCode = 404;
                respose.Response = "Please enter email which you used at the time of registration";
                respose.Message = "Try again";
                return Ok(respose);
            }
            respose.StatusCode = 200;
            respose.Response = "Email send to your registred email id";
            respose.Message = "success";
            return Ok(respose);
        }

        //Get Country API
        [HttpGet("Countries")]
        public IActionResult GetCounteries()
        {
            return Ok(_userService.GetCountries());
        }

        //Get States Api 
        [HttpGet("states")]
        public IActionResult GetStatebyCountryId()
        {
            return Ok(_userService.GetStatebyId());
        }

        //Get Role Api
        [HttpGet("Roles")]
        public IActionResult GetRoles()
        {
            return Ok(_userService.GetRoles());
        }

        //otp validation 
        [HttpPost("userid")]
        public IActionResult ValidOtp([FromBody] OtpValidateVM otp)
        {
            var responce = new OtpResponce();
            var userDetails = _otpService.ValidOtp(otp.userid, otp.otp);
            if (userDetails != null)
            {
                return Ok(userDetails);
            }
            responce.Response = "Please try again";
            responce.Message = "Please Enter valid otp";
            responce.UserRole = 0;
            responce.StatusCode = 400;
            return Ok(responce);
        }
    }
}

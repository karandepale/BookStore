using BookStore.User.Interfaces;
using BookStore.User.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStore.User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo userRepo;
        public UserController(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }


        //USER REGISTRATION:-
        [HttpPost]
        [Route("User_Registration")]
        public IActionResult Registration(UserRegistrationModel model)
        {
            var result = userRepo.UserRegistration(model);
            if (result != null)
            {
                return Ok(new { success = true, message = "User Registration Successful", data = result });
            }
            else
            {
                return BadRequest(new { success = false, message = "User Registration Failed", data = result });
            }
        }



        //GET ALL USERS:-
        [HttpGet]
        [Route("GetAll_User")]
        public IActionResult GetAllUser()
        {
            var result = userRepo.GetAllUser();
            if (result != null)
            {
                return Ok(new { success = true, message = "User List Getting Successful", data = result });
            }
            else
            {
                return NotFound(new { success = false, message = "User List Getting Failed", data = result });
            }
        }


        //USER LOGIN:-
        [HttpPost]
        [Route("UserLogin")]
        public IActionResult Login(UserLoginModel model)
        {
            var result = userRepo.UserLogin(model);
            if (result != null)
            {
                return Ok(new { success = true, message = "User Login Successful", data = result });
            }
            else
            {
                return BadRequest(new { success = false, message = "User Login Failed", data = result });
            }
        }



        // FORGOT PASSWORD:-
        [HttpPost]
        [Route("Forgot_Password")]
        public IActionResult ForgotPassword(ForgotPassModel model)
        {
            var result = userRepo.ForgotPassword(model);
            if (result != null)
            {
                return Ok(new { success = true, message = "Forgot pass Token send on your mail Send Successfully" });
            }
            else
            {
                return NotFound(new { success = false, message = "Forgot pass email not send..." });
            }
        }



        // RESET PASSWORD:-
        [Authorize]
        [HttpPost]
        [Route("ResetPass")]
        public IActionResult ResetPassword(string newPass, string confirmPass)
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;
            var result = userRepo.ResetPassword(email, newPass, confirmPass);
            if (result != null)
            {
                return Ok(new { success = true, message = "Password Changed Successfully", data = result });
            }
            else
            {
                return NotFound(new { success = false, message = "Password not changed", data = result });
            }
        }



    }
}

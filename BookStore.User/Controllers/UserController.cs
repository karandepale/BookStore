using BookStore.User.Interfaces;
using BookStore.User.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

    }
}

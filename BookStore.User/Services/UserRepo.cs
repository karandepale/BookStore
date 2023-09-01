using BookStore.User.Context;
using BookStore.User.Entity;
using BookStore.User.Interfaces;
using BookStore.User.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.User.Services
{
    public class UserRepo : IUserRepo
    {
        private readonly UserContext userContext;
        private readonly IConfiguration configuration;
        public UserRepo(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }


        // JWT TOKEN GENERATE:-
        public string GenerateJwtToken(string Email, long UserID)
        {
            var claims = new List<Claim>
            {
                new Claim("UserID", UserID.ToString()),
                new Claim(ClaimTypes.Email, Email),
        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["JwtSettings:Issuer"], configuration["JwtSettings:Audience"], claims, DateTime.Now, DateTime.Now.AddHours(1), creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        //USER REGISTRATION:-
        public UserEntity UserRegistration(UserRegistrationModel model)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.FirstName = model.FirstName;
                userEntity.LastName = model.LastName;
                userEntity.Email = model.Email;
                userEntity.Password = model.Password;
                userEntity.Address = model.Address;

                userContext.User.Add(userEntity);
                userContext.SaveChanges();
                if (userEntity != null)
                {
                    return userEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        //GET ALL USERS:-
        public List<UserEntity> GetAllUser()
        {
            try
            {
                var userList = userContext.User.ToList();
                if(userList != null)
                {
                    return userList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        // GET USER BY ID:-
        public UserEntity GetUserByID(int userID)
        {
            try
            {
                var user = userContext.User.FirstOrDefault
                    (data => data.UserID == userID);
                if(user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        //USER LOGIN:-
        public UserLoginResult UserLogin(UserLoginModel model)
        {
            try
            {
                var result = userContext.User.FirstOrDefault
                    (data => data.Email == model.Email && data.Password == model.Password);
                if (result != null)
                {
                    return new UserLoginResult
                    {
                        UserEntity = result,
                        JwtToken = GenerateJwtToken(result.Email, result.UserID)
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        // FORGOT PASSWORD IMPLEMENTATION USINF MSMQ:-
        public string ForgotPassword(ForgotPassModel model)
        {
            try
            {
                var result = userContext.User.FirstOrDefault(u => u.Email == model.Email);
                if (result != null)
                {
                    var Token = GenerateJwtToken(result.Email, result.UserID);
                    MSMQ msmq = new MSMQ();
                    msmq.SendData2Queue(Token);

                    return Token;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }


        // RESET PASSWORD:-
        public bool ResetPassword(string email, string newPass, string confirmPass)
        {
            try
            {
                if (newPass == confirmPass)
                {
                    var isEmailPresent = userContext.User.FirstOrDefault(user => user.Email == email);
                    isEmailPresent.Password = confirmPass;
                    userContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }



    }
}

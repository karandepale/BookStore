using BookStore.Admin.Context;
using BookStore.Admin.Entity;
using BookStore.Admin.Interfaces;
using BookStore.Admin.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.Admin.Services
{
    public class AdminRepo : IAdminRepo
    {
        private readonly AdminContext adminContext;
        private readonly IConfiguration configuration;  
        public AdminRepo(AdminContext adminContext , IConfiguration configuration)
        {
            this.adminContext = adminContext;
            this.configuration = configuration;
        }


        //ADMIN REGISTRATION:-
        public AdminEntity Registration(AdminRegistrationModel model)
        {
            try
            {
                AdminEntity adminEntity = new AdminEntity();
                adminEntity.FirstName = model.FirstName;
                adminEntity.LastName = model.LastName;
                adminEntity.Email = model.Email;
                adminEntity.Password = model.Password;

                adminContext.Admin.Add(adminEntity);
                adminContext.SaveChanges();
                if (adminEntity != null)
                {
                    return adminEntity;
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


        //GET ALL ADMINS:-
        public List<AdminEntity> GetAllAdmin()
        {
            try
            {
                var adminList = adminContext.Admin.ToList();
                if(adminList != null)
                {
                    return adminList;
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



        //GENERATE JWT :-
        public string GenerateJwtToken(string Email, long AdminID)
        {
            var claims = new List<Claim>
            {
                new Claim("AdminID", AdminID.ToString()),
                new Claim(ClaimTypes.Email, Email),
        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken("JwtSettings:Issuer", "JwtSettings:Audience", claims, DateTime.Now, DateTime.Now.AddHours(1), creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




        //ADMIN LOGIN:-
        public AdminLoginResult AdminLogin(AdminLoginModel model)
        {
            try
            {
                var result = adminContext.Admin.FirstOrDefault
                    (data => data.Email == model.Email && data.Password == model.Password);
                if (result != null)
                {
                    return new AdminLoginResult
                    {
                        AdminEntity = result,
                        JwtToken = GenerateJwtToken(result.Email, result.AdminID)
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




    }
}

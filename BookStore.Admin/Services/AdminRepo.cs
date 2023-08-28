using BookStore.Admin.Context;
using BookStore.Admin.Entity;
using BookStore.Admin.Interfaces;
using BookStore.Admin.Model;

namespace BookStore.Admin.Services
{
    public class AdminRepo : IAdminRepo
    {
        private readonly AdminContext adminContext;
        public AdminRepo(AdminContext adminContext)
        {
            this.adminContext = adminContext;
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




    }
}

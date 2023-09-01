using BookStore.User.Entity;
using BookStore.User.Model;

namespace BookStore.User.Interfaces
{
    public interface IUserRepo
    {
        public UserEntity UserRegistration(UserRegistrationModel model);
        public List<UserEntity> GetAllUser();
        public UserEntity GetUserByID(int userID);
        public UserLoginResult UserLogin(UserLoginModel model);
        public string ForgotPassword(ForgotPassModel model);
        public bool ResetPassword(string email, string newPass, string confirmPass);
    }
}

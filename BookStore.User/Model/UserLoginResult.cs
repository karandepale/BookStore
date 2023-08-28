using BookStore.User.Entity;

namespace BookStore.User.Model
{
    public class UserLoginResult
    {
        public UserEntity UserEntity { get; set; }
        public string JwtToken { get; set; }
    }
}

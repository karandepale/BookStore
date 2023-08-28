using BookStore.Admin.Entity;

namespace BookStore.Admin.Model
{
    public class AdminLoginResult
    {
        public AdminEntity AdminEntity { get; set; }
        public string JwtToken { get; set; }
    }
}

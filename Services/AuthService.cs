using Fiap.Api.WasteManagementApplication.Models;

namespace Fiap.Api.WasteManagementApplication.Services
{
    public class AuthService : IAuthService
    {
        private List<UserModel> _users = new List<UserModel>
                {
                    new UserModel { UserId = 1, Username = "lucca", Password = "lucca", Role = "admin" },
                    new UserModel { UserId = 2, Username = "guilherme", Password = "guilherme", Role = "admin" },
                    new UserModel { UserId = 3, Username = "camila", Password = "camila", Role = "user" },
                    new UserModel { UserId = 4, Username = "bruna", Password = "bruna", Role = "user" },
                    new UserModel { UserId = 5, Username = "lucas", Password = "lucas", Role = "user" },
                };


        public UserModel Authenticate(string username, string password)
        {
            return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}

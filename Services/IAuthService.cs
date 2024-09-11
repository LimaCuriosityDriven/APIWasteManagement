using Fiap.Api.WasteManagementApplication.Models;

namespace Fiap.Api.WasteManagementApplication.Services
{
        public interface IAuthService
        {
            UserModel Authenticate(string username, string password);

        }
}

using Backend.business.DataAccess.Models;

namespace Backend.bussiness.webApi.Controllers
{
    public interface IAuthServices
    {
        Users Authenticate(Login Logins);
        string Token(Users user);
    }
}
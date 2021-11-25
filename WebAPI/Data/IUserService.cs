using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}
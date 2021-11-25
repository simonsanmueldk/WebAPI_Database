using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.RepositoryImpls
{
    public interface IUserRepo
    {

        Task<User> ValidateUser(string userName, string Password);
    }
}
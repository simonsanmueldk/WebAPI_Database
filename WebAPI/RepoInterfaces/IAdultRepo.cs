using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.RepositoryImpls
{
    public interface IAdultRepo
    {
        Task<List<Adult>> GetAsync();
        Task AddAsync(Adult adult);
        
    }
}
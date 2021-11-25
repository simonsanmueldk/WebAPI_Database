using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.DataAcces;
using WebAPI.Models;

namespace WebAPI.RepositoryImpls
{
    public class AdultRepo:IAdultRepo
    {

        private AdultDbContext ctx;

        public AdultRepo(AdultDbContext ctx)
        {
            this.ctx = ctx;
        }


        public async Task<List<Adult>> GetAsync()
        {
            return await ctx.Adults.Include(a=>a.JobTitle).ToListAsync();

        }

        public async Task AddAsync(Adult adult)
        {
            await ctx.Adults.AddAsync(adult);
            await ctx.SaveChangesAsync();
        }
    }
}
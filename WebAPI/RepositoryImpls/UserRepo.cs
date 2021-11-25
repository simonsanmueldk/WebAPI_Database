using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.DataAcces;
using WebAPI.Models;

namespace WebAPI.RepositoryImpls
{
    public class UserRepo: IUserRepo
    {
        private AdultDbContext ctx;

        public UserRepo(AdultDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<User> ValidateUser(string userName, string password)
        {
            User temp = await ctx.Users.FirstOrDefaultAsync(u => u.UserName.Equals(userName));
            if (temp == null)
            {
                throw new Exception("User was not found");
            }

            if (!temp.Password.Equals(password))
            {
              
                throw new Exception("Incorrect password, try again");
            }

            return temp;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;
using FileData;

namespace WebAPI.Data.Impl
{
    public class PersistenceUsers : IUserService
    {
        private UsersFileContext _usersFileContext;

        public PersistenceUsers()
        {
            _usersFileContext = new UsersFileContext();
        }
        
        public User ValidateUser(string userName, string password)
        {
            IList<User> users = _usersFileContext.Users;
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null) {
                return null;
            }

            if (!first.Password.Equals(password)) {
                return null;
            }

            return first;
        }


    }
}
using DinnerCafe.Application.common.Interface.Persistence;
using DinnerCafe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerCafe.Infrastructure.persistence
{
    public class UserRepositories : IUserRepositories
    {
        private readonly List<User> _Users = new List<User>();
        public void AddUser(User User)
        {
            _Users.Add(User);
        }

        public User? GetUserbyEmailId(string Email)
        {
           return _Users.SingleOrDefault(x => x.Email == Email);    
        }
    }
}

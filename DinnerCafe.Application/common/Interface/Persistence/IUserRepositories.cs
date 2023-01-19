using DinnerCafe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerCafe.Application.common.Interface.Persistence
{
    public interface IUserRepositories
    {
        public User? GetUserbyEmailId(string Email);
       public void AddUser(User User);
    }
}

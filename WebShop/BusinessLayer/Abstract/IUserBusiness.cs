using Core.Result;
using Entities;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserBusiness
    {
        ResultWrapper Login(LoginDTO loginDTO);
        ResultWrapper Add(User user);
        ResultWrapper Update(User user);
        ResultWrapper Delete(User user);
        List<User> GetUsers();

        User GetById(int id);
       
    }
}

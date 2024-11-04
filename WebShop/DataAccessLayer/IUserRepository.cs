﻿using Core.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IUserRepository:IRepository<User>
    {
        User GetByEmail(string email);
    }
}

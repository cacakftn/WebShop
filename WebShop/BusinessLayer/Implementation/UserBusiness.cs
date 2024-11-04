using BusinessLayer.Abstract;
using Core.Bezbednost;
using Core.Result;
using DataAccessLayer;
using Entities;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository userRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public ResultWrapper Login(LoginDTO loginDTO)
        {
            User user = userRepository.GetByEmail(loginDTO.Email!);
            if (user == null)
            {
                return new ResultWrapper
                {
                    Success = false,
                    Message = "The user does not exist"
                };
            }
            else
            {
                if(HashingHelper.VerifyHash(loginDTO.Password!, user.PasswordHash!) == true)
                {
                    return new ResultWrapper
                    {
                        Success = true,
                        Message = "Success"
                    };
                }
                else
                {
                    return new ResultWrapper
                    {
                        Success = false,
                        Message = "Wrong username and password"
                    };
                }
            }
        }
    }
}

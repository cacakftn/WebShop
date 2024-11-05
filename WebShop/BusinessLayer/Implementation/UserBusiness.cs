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
        private readonly IOrderRepository orderRepository;

        public UserBusiness(IUserRepository userRepository, IOrderRepository orderRepository)
        {
            this.userRepository = userRepository;
            this.orderRepository = orderRepository;
        }

        public ResultWrapper Add(User user)
        {
            if (userRepository.Add(user) == true)
            {
                return new ResultWrapper
                {
                    Message = "Uspenso dodat",
                    Success = true
                };
            }
            else
            {
                return new ResultWrapper
                {
                    Message = "Greska",
                    Success = false
                };
            }
        }

        public ResultWrapper Delete(User user)
        {
            if(orderRepository.GetOrderByUserId(user.IdUser)  > 0)
            {
                return new ResultWrapper
                {
                    Message = "Korisnicki nalog je povezan sa tabelom order",
                    Success = false
                };
            }
            else
            {
                if(userRepository.Delete(user) == true)
                {
                    return new ResultWrapper
                    {
                        Message = "Uspesno obrisan nalog",
                        Success = true
                    };
                }
                else
                {
                    return new ResultWrapper
                    {
                        Message = "Greska",
                        Success = false
                    };
                }

            }
        }

        public User GetById(int id)
        {
           var x = userRepository.GetAll().Find(item => item.IdUser == id);
            if (x == null) return new User();
            return x;
        }

        public List<User> GetUsers()
        {
           return userRepository.GetAll();
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

        public ResultWrapper Update(User user)
        {
            return userRepository.Update(user) == true ?
                new ResultWrapper
                {
                    Message = "Uspeh",
                    Success = true
                } : new ResultWrapper
                {
                    Message = "Greska",
                    Success = false
                };
        }
    }
}

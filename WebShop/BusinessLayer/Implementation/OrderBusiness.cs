using BusinessLayer.Abstract;
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
    public class OrderBusiness : IOrderBusiness
    {
        private readonly IUserBusiness userBusiness;
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;

        public OrderBusiness(IUserBusiness userBusiness, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            this.userBusiness = userBusiness;
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }

        public ResultWrapper AddOrder(Order order)
        {
            User user = userBusiness.GetById(order.IdUser);
            Product? product = productRepository.GetAll().Find(x=>x.IdProduct == order.IdProduct);
            Order? order1 = orderRepository.GetAll().Find(x=>x.IdOrder==order.IdOrder && x.IdUser==order.IdUser);

            if (user.Satus == true)
            {
                if(order1 == null)
                {
                    if (product!.CountProduct > 0)
                    {
                        order1 = new Order();
                        order1!.TotalPrice = product!.Price;
                        orderRepository.Add(order1);
                        product.CountProduct = product.CountProduct - 1;
                        productRepository.Update(product);
                        return new ResultWrapper
                        {
                            Message = "Uspesno",
                            Success = true
                        };
                    }
                    else
                    {
                        return new ResultWrapper
                        {
                            Message = "Proizvod nema u bazi",
                            Success = false
                        };
                    }
                }
                else
                {
                    if (product!.CountProduct > 0)
                    {
                        order1!.TotalPrice = order.TotalPrice + product!.Price;
                        orderRepository.Update(order1);
                        product.CountProduct = product.CountProduct - 1;
                        productRepository.Update(product);
                        return new ResultWrapper
                        {
                            Message = "Uspesno",
                            Success = true
                        };
                    }
                    else
                    {
                        return new ResultWrapper
                        {
                            Message = "Proizvod nema u bazi",
                            Success = false
                        };
                    }
                }
            }
            else
            {
                return new ResultWrapper
                {
                    Message = "Nalog nije aktivan",
                    Success = false
                };
            }
          
        }

        public List<Order> GetAllOrders()
        {
            return orderRepository.GetAll();
        }

        public ResultWrapper GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserOrderDTO> GetUserOrderDTOs()
        {
          return  orderRepository.GetUserOrderDTOs();
        }

        public ResultWrapper RemoveOrder(Order order)
        {
            User user = userBusiness.GetById(order.IdUser);
            Product? product = productRepository.GetAll().Find(x => x.IdProduct == order.IdProduct);
            Order? order1 = orderRepository.GetAll().Find(x => x.IdOrder == order.IdOrder);

            if (user.Satus == true)
            {
                if (order1 != null)
                {
                    order1.TotalPrice = order1.TotalPrice - product!.Price;
                    orderRepository.Update(order1);
                    product.CountProduct = product.CountProduct + 1;
                    productRepository.Update(product);
                    orderRepository.Delete(order);
                    return new ResultWrapper
                    {
                        Message = "Uspesno",
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
            else
            {
                return new ResultWrapper
                {
                    Message = "Nalog nije aktivan",
                    Success = false
                };
            }
        }

        public ResultWrapper UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}

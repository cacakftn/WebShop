using Core.Result;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOrderBusiness
    {
        ResultWrapper AddOrder(Order order);
        ResultWrapper RemoveOrder(Order order);
        ResultWrapper GetOrderById(int id);
        ResultWrapper UpdateOrder(Order order);
        List<Order> GetAllOrders();
    }
}

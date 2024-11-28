using Core.Interface;
using Entities;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IOrderRepository :IRepository<Order>
    {
        int GetOrderByUserId(int userId);
        List<UserOrderDTO> GetUserOrderDTOs();
    }
}

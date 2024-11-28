

using DataAccessLayer;
using Entities;

namespace TestConsols
{
    internal class Program
    {
        static void Main(string[] args)
        {

           IOrderRepository orderRepository = new OrderRepository();

            var lista = orderRepository.GetUserOrderDTOs();
            foreach (var item in lista)
            {
                Console.WriteLine(item.FrstName+" "+item.Price);
            }

        }
    }
}
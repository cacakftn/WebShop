using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class UserOrderDTO
    {
        public int IdUser { get; set; }
        public string? FrstName { get; set; }
        public string? LastName { get; set; }
        public int IdProduct { get; set; }
        
        public string? NameProduct { get; set; }
        public decimal Price { get; set; }
        public int IdOrder { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}

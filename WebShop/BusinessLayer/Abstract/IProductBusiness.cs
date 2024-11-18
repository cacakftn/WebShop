using Core.Result;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductBusiness
    {
        ResultWrapper AddProduct(Product product);
        ResultWrapper DeleteProduct(Product product);
        ResultWrapper UpdateProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
    }
}

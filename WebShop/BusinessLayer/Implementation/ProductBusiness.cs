using BusinessLayer.Abstract;
using Core.Result;
using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductRepository productRepository;

        public ProductBusiness(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public ResultWrapper AddProduct(Product product)
        {
            if (productRepository.Add(product) == true)
            {
                return new ResultWrapper
                {
                    Message ="Uspesno",
                    Success = true
                };
            }
            return new ResultWrapper
            {
                Message = "Greska",
                Success = false
            };
        }

        public ResultWrapper DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            return this.productRepository.GetAll();
        }

        public Product GetProductById(int id)
        {
            Product? product = productRepository.GetAll().Find(x => x.IdProduct == id);

            if (product != null)
            {
                return product;
            }
            return new Product();
        }

        public ResultWrapper UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}

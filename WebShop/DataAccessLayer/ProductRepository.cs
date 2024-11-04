using DataAccessLayer.Constat;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductRepository : IProductRepository
    {
        public bool Add(Product item)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "insert into Products(Name,Description,Price,CountProduct,IdCategory) values(@Name,@Description,@Price,@CountProduct,@IdCategory)";
                sqlCommand.Parameters.AddWithValue("@Name", item.Name);
                sqlCommand.Parameters.AddWithValue("@Description", item.Description);
                sqlCommand.Parameters.AddWithValue("@Price", item.Price);
                sqlCommand.Parameters.AddWithValue("@CountProduct", item.CountProduct);
                sqlCommand.Parameters.AddWithValue("@IdCategory", item.IdCategory);
                

                int res = sqlCommand.ExecuteNonQuery();

                return res > 0;
            }
        }

        public bool Delete(Product item)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "DELETE FROM Products WHERE IdProduct=@IdProduct";
                sqlCommand.Parameters.AddWithValue("@IdProduct", item.IdProduct);


                int res = sqlCommand.ExecuteNonQuery();

                return res > 0;
            }
        }

        public List<Product> GetAll()
        {
            List<Product> list = new List<Product>();

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Products";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Product product = new Product();
                    product.IdProduct = sqlDataReader.GetInt32(0);
                    product.Name = sqlDataReader.GetString(1);
                    product.Description = sqlDataReader.GetString(2);
                    product.Price = sqlDataReader.GetDecimal(3);
                    product.CountProduct = sqlDataReader.GetInt32(4);
                    product.IdCategory = sqlDataReader.GetInt32(5);
                    list.Add(product);

                }

            }
            return list;
        }

        public bool Update(Product item)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "UPDATE Products SET Name=@Name, Description=@Description," +
                    "Price=@Price,CountProduct=@CountProduct, IdCategory=@IdCategory WHERE IdProduct=@IdProduct";
                sqlCommand.Parameters.AddWithValue("@Name", item.Name);
                sqlCommand.Parameters.AddWithValue("@Description", item.Description);
                sqlCommand.Parameters.AddWithValue("@Price", item.Price);
                sqlCommand.Parameters.AddWithValue("@CountProduct", item.CountProduct);
                sqlCommand.Parameters.AddWithValue("@IdCategory", item.IdCategory);
                sqlCommand.Parameters.AddWithValue("@IdProduct", item.IdProduct);
               
                int res = sqlCommand.ExecuteNonQuery();

                return res > 0;
            }
        }
    }
}

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
    public class OrderRepository : IOrderRepository
    {
        public bool Add(Order item)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "insert into Orders(TotalPrice,IdUser,IdProduct) values(@TotalPrice,@IdUser,@IdProduct)";
                sqlCommand.Parameters.AddWithValue("@TotalPrice", item.TotalPrice);
                sqlCommand.Parameters.AddWithValue("@IdUser", item.IdUser);
                sqlCommand.Parameters.AddWithValue("@IdProduct", item.IdProduct);


                int res = sqlCommand.ExecuteNonQuery();

                return res > 0;
            }
        }

        public bool Delete(Order item)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
}

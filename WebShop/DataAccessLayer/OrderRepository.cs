using DataAccessLayer.Constat;
using Entities;
using Entities.DTO;
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
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "DELETE FROM Orders WHERE IdOrder=@IdOrder";
                sqlCommand.Parameters.AddWithValue("@IdOrder", item.IdOrder);


                int res = sqlCommand.ExecuteNonQuery();

                return res > 0;
            }
        }

        public List<Order> GetAll()
        {
            List<Order> list = new List<Order>();

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Orders";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Order order = new Order();

                    order.IdOrder = sqlDataReader.GetInt32(0);
                    order.TotalPrice = sqlDataReader.GetDecimal(1);
                    order.OrderDate = sqlDataReader.GetDateTime(2);
                    order.IdUser = sqlDataReader.GetInt32(3);
                    order.IdProduct = sqlDataReader.GetInt32(4);
                    list.Add(order);


                }

            }
            return list;
        }

        public int GetOrderByUserId(int userId)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT Count(*) FROM Orders WHERE IdUser=@UserId";
                sqlCommand.Parameters.AddWithValue("@UserId", userId);


                int res = (int) sqlCommand.ExecuteScalar();

                return res;
               
            }
        }

        public List<UserOrderDTO> GetUserOrderDTOs()
        {
            List<UserOrderDTO> list = new List<UserOrderDTO>();

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT u.IdUser, u.FrstName, u.LastName," +
                    "p.IdProduct,\r\np.Name, p.Price,o.IdOrder, " +
                    "o.TotalPrice, o.OrderDate\r\nFROM Users u " +
                    "JOIN Orders o ON u.IdUser=o.IdUser\r\nJOIN " +
                    "Products p ON o.IdProduct = p.IdProduct";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    UserOrderDTO userOrderDTO = new UserOrderDTO();
                    userOrderDTO.IdUser = sqlDataReader.GetInt32(0);
                    userOrderDTO.FrstName = sqlDataReader.GetString(1);
                    userOrderDTO.LastName = sqlDataReader.GetString(2);
                    userOrderDTO.IdProduct = sqlDataReader.GetInt32(3);
                    userOrderDTO.NameProduct = sqlDataReader.GetString(4);
                    userOrderDTO.Price = sqlDataReader.GetDecimal(5);
                    userOrderDTO.IdOrder = sqlDataReader.GetInt32(6);
                    userOrderDTO.TotalPrice = sqlDataReader.GetDecimal(7);
                    userOrderDTO.OrderDate = sqlDataReader.GetDateTime(8);
                    list.Add(userOrderDTO);


                }

            }
            return list;
        }

        public bool Update(Order item)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "UPDATE Orders SET TotalPrice=@TotalPrice,IdUser=@IdUser," +
                    "IdProduct=@IdProduct  WHERE IdOrder=@IdOrder";
                sqlCommand.Parameters.AddWithValue("@TotalPrice", item.TotalPrice);
                sqlCommand.Parameters.AddWithValue("@IdUser", item.IdUser);
                sqlCommand.Parameters.AddWithValue("@IdProduct", item.IdProduct);
                sqlCommand.Parameters.AddWithValue("@IdOrder", item.IdOrder);

                int res = sqlCommand.ExecuteNonQuery();

                return res > 0;
            }
        }
    }
}

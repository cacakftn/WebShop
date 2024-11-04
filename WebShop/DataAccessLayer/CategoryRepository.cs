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
    public class CategoryRepository : ICategoryRepository
    {
        public bool Add(Category item)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "insert into Categories(Name) values(@Name)";
                sqlCommand.Parameters.AddWithValue("@Name", item.Name);
              

                int res = sqlCommand.ExecuteNonQuery();

                return res > 0;
            }

        }

        public bool Delete(Category item)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "DELETE FROM Categories WHERE IdCategory=@IdCategory";
                sqlCommand.Parameters.AddWithValue("@IdCategory", item.IdCategory);


                int res = sqlCommand.ExecuteNonQuery();

                return res > 0;
            }
        }

        public List<Category> GetAll()
        {
            List<Category> list = new List<Category>();

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Categories";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Category category = new Category();

                    category.IdCategory = sqlDataReader.GetInt32(0); ;
                    category.Name = sqlDataReader.GetString(1);
                    list.Add(category);

                }

            }
            return list;
        }

        public bool Update(Category item)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "UPDATE Categories SET Name=@Name WHERE IdCategory=@IdCategory";
                sqlCommand.Parameters.AddWithValue("@Name", item.Name);
                sqlCommand.Parameters.AddWithValue("@IdCategory", item.IdCategory);
              
                int res = sqlCommand.ExecuteNonQuery();

                return res > 0;
            }
        }
    }
}

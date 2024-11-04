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
    public class UserRepository : IUserRepository
    {
        public bool Add(User item)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "insert into Users(FrstName,LastName,Email,PasswordHash,Status,IdRole) values(@FrstName,@LastName,@Email,@PasswordHash,@Status,@IdRole)";
                sqlCommand.Parameters.AddWithValue("@FrstName", item.FrstName);
                sqlCommand.Parameters.AddWithValue("@LastName", item.LastName);
                sqlCommand.Parameters.AddWithValue("@Email", item.Email);
                sqlCommand.Parameters.AddWithValue("@PasswordHash", item.PasswordHash);
                sqlCommand.Parameters.AddWithValue("@Status", item.Satus);
                sqlCommand.Parameters.AddWithValue("@IdRole", item.IdRole);

                int res = sqlCommand.ExecuteNonQuery();

                return res > 0;
            }
        }

        public bool Delete(User item)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "DELETE FROM Users WHERE IdUser=@IdUser";
                sqlCommand.Parameters.AddWithValue("@IdUser", item.IdUser);
              

                int res = sqlCommand.ExecuteNonQuery();

                return res > 0;
            }
        }

        public List<User> GetAll()
        {
            List<User> list = new List<User>();

            using(SqlConnection sqlConnection= new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Users";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while(sqlDataReader.Read())
                {
                    User user = new User();
                    user.IdUser = sqlDataReader.GetInt32(0);
                    user.FrstName = sqlDataReader.GetString(1);
                    user.LastName = sqlDataReader.GetString(2);
                    user.Email = sqlDataReader.GetString(3);
                    user.PasswordHash = sqlDataReader.GetString(4);
                    user.Satus = sqlDataReader.GetBoolean(5);
                    user.CreatedDate = sqlDataReader.GetDateTime(6);
                    user.IdRole = sqlDataReader.GetInt32(7);
                    list.Add(user);

                }

            }
            return list;
        }

        public User GetByEmail(string email)
        {
            User user1 = new User();

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Users where Email = @Email";
                sqlCommand.Parameters.AddWithValue("@Email", email);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                {
                   
                    user1.IdUser = sqlDataReader.GetInt32(0);
                    user1.FrstName = sqlDataReader.GetString(1);
                    user1.LastName = sqlDataReader.GetString(2);
                    user1.Email = sqlDataReader.GetString(3);
                    user1.PasswordHash = sqlDataReader.GetString(4);
                    user1.Satus = sqlDataReader.GetBoolean(5);
                    user1.CreatedDate = sqlDataReader.GetDateTime(6);
                    user1.IdRole = sqlDataReader.GetInt32(7);
                    

                }

            }
            return user1;
        }

        public bool Update(User item)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "UPDATE Users SET FrstName=@FrstName, LastName=@LastName," +
                    "Email=@Email,PasswordHash=@PasswordHash, Status=@Status, IdRole=@IdRole WHERE IdUser=@IdUser";
                sqlCommand.Parameters.AddWithValue("@FrstName", item.FrstName);
                sqlCommand.Parameters.AddWithValue("@LastName", item.LastName);
                sqlCommand.Parameters.AddWithValue("@Email", item.Email);
                sqlCommand.Parameters.AddWithValue("@PasswordHash", item.PasswordHash);
                sqlCommand.Parameters.AddWithValue("@Status", item.Satus);
                sqlCommand.Parameters.AddWithValue("@IdRole", item.IdRole);
                sqlCommand.Parameters.AddWithValue("@IdUser", item.IdUser);
                int res = sqlCommand.ExecuteNonQuery();

                return res > 0;
            }
        }
    }
}

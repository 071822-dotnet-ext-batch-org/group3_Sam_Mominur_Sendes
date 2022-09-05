using ModelsLayer;
using System.Data.SqlClient;
using System.Net.Sockets;

namespace RepoLayer
{
    public class Repo
    {
        /// <summary>
        /// #1 Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<LoginDto> LoginAsync(LoginDto login)
        {
            SqlConnection conn1 = new SqlConnection("Server=tcp:p2group3.database.windows.net,1433;Initial Catalog=P2Group3;Persist Security Info=False;User ID=p2group3;Password=project2groupthree!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT UserName, Password FROM Users WHERE UserName = @username AND Password = @password", conn1))
            {
                command.Parameters.AddWithValue("@username", login.UserName);
                command.Parameters.AddWithValue("@password", login.Password);
                conn1.Open();
                SqlDataReader ret = await command.ExecuteReaderAsync();

                if (ret.Read())
                {
                    LoginDto login1 = new LoginDto(ret.GetString(0), ret.GetString(1));
                    return login1;
                }
                conn1.Close();
                return null;
            }
        }

        /// <summary>
        /// #2 Register a new account
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public async Task<User> NewUserAsync(User newUser)
        {
            SqlConnection conn1 = new SqlConnection("Server=tcp:p2group3.database.windows.net,1433;Initial Catalog=P2Group3;Persist Security Info=False;User ID=p2group3;Password=project2groupthree!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"UPDATE Users SET UserID = @id, UserName = @un, FirstName = @fn, LastName = @ln, Password = @pw, Email = @em, Role = @rl WHERE UserName = @un IF @@ROWCOUNT = 0 INSERT INTO Users (UserID, UserName, FirstName, LastName, Password, Email, Role) VALUES (@id, @un, @fn, @ln, @pw, @em, @rl)", conn1))
            {
                command.Parameters.AddWithValue("@id", newUser.UserID);
                command.Parameters.AddWithValue("@un", newUser.UserName);
                command.Parameters.AddWithValue("@fn", newUser.FirstName);
                command.Parameters.AddWithValue("@ln", newUser.LastName);
                command.Parameters.AddWithValue("@pw", newUser.Password);
                command.Parameters.AddWithValue("@em", newUser.Email);
                command.Parameters.AddWithValue("@rl", newUser.Role);

                conn1.Open();

                int ret = await command.ExecuteNonQueryAsync();

                if (ret > 0)
                {
                    return newUser;
                }
                conn1.Close();
                return null;
            }

        }

        /// <summary>
        /// #3 Display Products
        /// </summary>
        /// <returns></returns>
        public async Task<List<DisplayDto>> ProductDisplayAsync()
        {
            // made a connection wusing Sql connection class
            SqlConnection conn1 = new SqlConnection("Server=tcp:p2group3.database.windows.net,1433;Initial Catalog=P2Group3;Persist Security Info=False;User ID=p2group3;Password=project2groupthree!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT ProductId, ProductName, ProductDetails, ProductPrice, ProductInventory FROM Products", conn1)) //created a command using the query and the connection string,
            {
                //I gave parameter to the command
                conn1.Open();                                   // opening connection
                SqlDataReader? ret = await command.ExecuteReaderAsync(); //Reding data from the db, (read only)
                List<DisplayDto> tList = new List<DisplayDto>(); //creating list as empty list naming it tList

                while (ret.Read()) //advances to the first row
                {
                    DisplayDto t = new DisplayDto((Guid)ret[0], ret.GetString(1), ret.GetString(2), ret.GetDecimal(3), ret.GetInt32(4));
                    tList.Add(t);
                }
                conn1.Close();
                return tList;
            }
        }
    }
}
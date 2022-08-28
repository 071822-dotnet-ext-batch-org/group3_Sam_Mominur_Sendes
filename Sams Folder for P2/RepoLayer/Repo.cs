using ModelsLayer;
using System.Data.SqlClient;

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
            SqlConnection conn1 = new SqlConnection("Server=tcp:revature.database.windows.net,1433;Initial Catalog=Group3Project2;Persist Security Info=False;User ID=samRevature;Password=Hulanlove23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
    }
}
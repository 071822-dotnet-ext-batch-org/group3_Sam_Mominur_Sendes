//Required Imports
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

//My Imports
using ModelLayer;
using static ModelLayer.Models;

namespace RepoLayer;
public class ADO_ACCESS : IADO_ACCESS
{
    private readonly IConfiguration _dbString;

    public ADO_ACCESS(IConfiguration config)
    {
        this._dbString = config;
    }

    /// <summary>
    /// This gets all the users in the DB
    /// </summary>
    /// <returns></returns>
    public async Task<List<Models.User>> GetUsersAsync()
    {
        SqlConnection conn = new SqlConnection(_dbString["_AppSecrets:ConnectionString"]);
        using (SqlCommand command = new SqlCommand("SELECT * FROM Users", conn))
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                Console.WriteLine($"Connection was closed and now open");
            }
            else
            {
                Console.WriteLine($"Connection was open and now closed and open");
                conn.Close();
                conn.Open();
            }
            Console.WriteLine("\n\n\t\tAbout to read for all Users\n\n");
            SqlDataReader data = await command.ExecuteReaderAsync();
            List<Models.User>? Users = new List<Models.User>();
            while(data.Read())
            {
                if (data.GetString(6) == "User")
                {
                    Models.User user = new Models.User();
                    user.PK_UserID = data.GetGuid(0);
                    user.Username = data.GetString(1);
                    user.Password = data.GetString(2);
                    user.FirstName = data.GetString(3);
                    user.LastName = data.GetString(4);
                    user.Email = data.GetString(5);
                    user.Role = Models.Status.User;
                    user.SignupDate = data.GetDateTime(7);
                    Users.Add(user);
                }
                else
                {
                    Models.User user = new Models.User();
                    user.PK_UserID = data.GetGuid(0);
                    user.Username = data.GetString(1);
                    user.Password = data.GetString(2);
                    user.FirstName = data.GetString(3);
                    user.LastName = data.GetString(4);
                    user.Email = data.GetString(5);
                    user.Role = Models.Status.Admin;
                    user.SignupDate = data.GetDateTime(7);
                    Users.Add(user);
                }
            }//END WHILE
            conn.Close();
            return Users;
        }//END USING
    }//END GET ALL USERS

    /// <summary>
    /// Registers the user using a Register DTO
    /// </summary>
    /// <param name="newUser"></param>
    /// <returns></returns>
    public async Task<bool> RegisterUserAsync(REGISTERDTO newUser)
    {
        SqlConnection conn = new SqlConnection(_dbString["_AppSecrets:ConnectionString"]);
        using (SqlCommand command = new SqlCommand("INSERT INTO Users " +
            "VALUES(@ID, @UN, @UP, @UF, @UL, @UE, @UR, @USD )", conn))
        {
            command.Parameters.AddWithValue("@ID", Guid.NewGuid());
            command.Parameters.AddWithValue("@UN", newUser.Username);
            command.Parameters.AddWithValue("@UP", newUser.Password);
            command.Parameters.AddWithValue("@UF", newUser.FirstName);
            command.Parameters.AddWithValue("@UL", newUser.LastName);
            command.Parameters.AddWithValue("@UR", Models.Status.User.ToString());
            command.Parameters.AddWithValue("@UE", newUser.Email);
            command.Parameters.AddWithValue("@USD", DateTime.Now);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                Console.WriteLine($"Connection was closed and now open");
            }
            else
            {
                Console.WriteLine($"Connection was open and now closed and open");
                conn.Close();
                conn.Open();
            }
            Console.WriteLine("\n\n\t\tAbout to read for all Users\n\n");
            int rowsChanged = await command.ExecuteNonQueryAsync();
            if(rowsChanged > 0)
            {
                Console.WriteLine($"\n\n\t\tRows changed were {rowsChanged}\n\n");
                conn.Close();
                return true;
            }
            else
            {
                Console.WriteLine($"\n\n\t\tRows changed were {rowsChanged}\n\n");
                conn.Close();
                return false;
            }
        }
    }



}

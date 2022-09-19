using System.Reflection;
using System.Runtime.InteropServices;

//Needed Imports
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

//My Imports
using BusinessLayer;
using ModelLayer;
using RepoLayer;

namespace User.Tests;

public class UsersTest_CONTROLLER : ControllerBase
{
    private IUser_BusinessLayer UBL;
    public UsersTest_CONTROLLER(IUser_BusinessLayer u_BL)
    {
        this.UBL = u_BL;
    }


    /// <summary>
    /// This tests if all users can be gotten
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task<IActionResult> GetUsers()
    {
        List<Models.User>? ALL_USERS = await this.UBL.GetUsers();
        return Ok(ALL_USERS);
    }
}//END OF CONTROLLER


public class UsersTest_BL
{
    private IADO_ACCESS _repo;
    public UsersTest_BL(IADO_ACCESS aDO)
    {
        this._repo = aDO;
    }


    /// <summary>
    /// This tests if all users can be gotten
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task<List<Models.User>> GetUsers()
    {
        List<Models.User> users = await this._repo.GetUsersAsync();
        return users;
    }
}//END OF BL


public class UsersTest_REPO
{
    private readonly IConfiguration _dbString;
    public UsersTest_REPO(IConfiguration _DBContext)
    {
        this._dbString = _DBContext;
    }


    /// <summary>
    /// This tests if all users can be gotten
    /// </summary>
    /// <returns></returns>
    [Fact]
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
            while (data.Read())
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
}//END OF REPO






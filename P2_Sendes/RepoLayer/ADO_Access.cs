namespace RepoLayer;
using ModelLayer;
using System.Data;
using System.Data.SqlClient;


public class ADO_Access : IADO_Access
{
    //private readonly string connection = $"Server=tcp:revature.database.windows.net,1433;Initial Catalog=Group3Project2;Persist Security Info=False;User ID=samRevature;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    private string myconnection = "Server=tcp:sendesdhaiti-revature-server.database.windows.net,1433;Initial Catalog=sendesdhaiti-revature-server;Persist Security Info=False;User ID=SendesD;Password=@Arcade30;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    /// <summary>
    /// Returns TRUE is saved
    /// Returns False if not saved
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<bool> Register_User(User user)
    {
        SqlConnection conn = new SqlConnection(myconnection);
        using (SqlCommand command = new SqlCommand("INSERT INTO Users " +
            "VALUES(@ID, @UF, @UL, @UP, @UE, @UR, @USD, @UN)", conn))
        {
            //-------------------------Commands Section
            command.Parameters.AddWithValue("@ID", user.PK_EmployeeID);
            command.Parameters.AddWithValue("@UN", user.Username);
            command.Parameters.AddWithValue("@UF", user.First);
            command.Parameters.AddWithValue("@UL", user.Last);
            command.Parameters.AddWithValue("@UP", user.Password);
            command.Parameters.AddWithValue("@UE", user.Email);
            command.Parameters.AddWithValue("@USD", user.SignupDate);
            if (user.Role == Status.User.ToString())
            {
                command.Parameters.AddWithValue("@UR", 0);
            }
            else if (user.Role == Status.Admin.ToString())
            {
                command.Parameters.AddWithValue("@UR", 1);
            }
            //int passedSave = 0;
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

            int save = await command.ExecuteNonQueryAsync();

            if(save >= 1)
            {
                Console.WriteLine($"Connection is now closed");
                conn.Close();
                return true;
            }
            else
            {
                Console.WriteLine($"Connection is now closed");
                conn.Close();
                return false;

            }

        }
    }//--------------------End of the User Register

    /// <summary>
    /// Returns TRUE if username exists already
    /// False if not
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<bool> CheckFor_User(User user)
    {
        Console.WriteLine($"\n\n\t\t\t{user.Username} --- Check FOr User If Exists - ADO\n\n");
        SqlConnection conn = new SqlConnection(myconnection);
        using(SqlCommand command = new SqlCommand("SELECT UserName from Users WHERE UserName=@UN", conn))
        {
            command.Parameters.AddWithValue("@UN", user.Username);
            //int passedCheck = 0;

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
            SqlDataReader check = await command.ExecuteReaderAsync();
            Console.WriteLine($"{check} --- check result - If Exists -- ADO ");
            string username = "";
            while (check.Read())
            {
                username = check.GetString(0);
            }
            if (username == user.Username)
            {
                //check successfully found the account with username
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;

            }
        }
    }//End Check if User Exists by Username

    public async Task<User?> Get_User(string username)
    {
        SqlConnection conn = new SqlConnection(myconnection);
        using (SqlCommand command = new SqlCommand("SELECT UserID, FirstName, LastName, Password, Email, Role, RegisterDate, UserName from Users WHERE UserName=@UN", conn))
        {
            command.Parameters.AddWithValue("@UN", username);
            //int passedCheck = 0;

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                //Console.WriteLine($"Connection was closed and now open");
            }
            else
            {
                //Console.WriteLine($"Connection was open and now closed and open");
                conn.Close();
                conn.Open();
            }
            Console.WriteLine("\n\n\t\tAbout to read for User\n\n");
            SqlDataReader check = await command.ExecuteReaderAsync();
            User loadedUser = new User();
            while (check.Read())
            {
                loadedUser.PK_EmployeeID = check.GetGuid(0);
                loadedUser.First = check.GetString(1);
                loadedUser.Last = check.GetString(2);
                loadedUser.Password = check.GetString(3);
                loadedUser.Email = check.GetString(4);
                if (check.GetBoolean(5) == false)
                {
                    loadedUser.Role = Status.User.ToString();

                }
                else if (check.GetBoolean(5) == true)
                {
                    loadedUser.Role = Status.Admin.ToString();
                }
                loadedUser.SignupDate = check.GetDateTime(6);
                loadedUser.Username = check.GetString(7);
                Console.WriteLine(
                    $"ID: {loadedUser.PK_EmployeeID}" +
                    $"ID: {loadedUser.Username}"
                    );
            }

            if (loadedUser == null)
            {
                //check did not find a user that matched both credentials
                conn.Close();
                return null;
            }
            else
            {
                conn.Close();
                return loadedUser;

            }
        }
    }//End of GET User 


    public async Task<User?> Login_User(string username, string password)
    {
        SqlConnection conn = new SqlConnection(myconnection);
        using (SqlCommand command = new SqlCommand("SELECT UserID, FirstName, LastName, Password, Email, Role, RegisterDate, UserName from Users WHERE UserName=@UN AND Password=@UP", conn))
        {
            command.Parameters.AddWithValue("@UN", username);
            command.Parameters.AddWithValue("@UP", password);
            //int passedCheck = 0;

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                //Console.WriteLine($"Connection was closed and now open");
            }
            else
            {
                //Console.WriteLine($"Connection was open and now closed and open");
                conn.Close();
                conn.Open();
            }
            Console.WriteLine("\n\n\t\tAbout to read for User\n\n");
            SqlDataReader check = await command.ExecuteReaderAsync();
            User loadedUser = new User();
            while (check.Read())
            {
                loadedUser.PK_EmployeeID = check.GetGuid(0);
                loadedUser.First = check.GetString(1);
                loadedUser.Last = check.GetString(2);
                loadedUser.Password = check.GetString(3);
                loadedUser.Email = check.GetString(4);
                if(check.GetBoolean(5) == false)
                {
                    loadedUser.Role = Status.User.ToString();

                }else if(check.GetBoolean(5) == true)
                {
                    loadedUser.Role = Status.Admin.ToString();
                }
                loadedUser.SignupDate = check.GetDateTime(6);
                loadedUser.Username = check.GetString(7);
                Console.WriteLine(
                    $"ID: {loadedUser.PK_EmployeeID}" +
                    $"ID: {loadedUser.Username}"
                    );
            }
            
            if (loadedUser == null)
            {
                //check did not find a user that matched both credentials
                conn.Close();
                return null;
            }
            else
            {
                conn.Close();
                return loadedUser;

            }
        }
    }//End of User Login



    public async Task<bool> Create_UserProfile(UserProfile profile)
    {
        User? user = new User();
        try
        {
            user = await Get_User(profile.Username);
        }
        catch
        {
            Console.WriteLine($"{profile.Username} was wrong");
        }


        SqlConnection conn = new SqlConnection(myconnection);
        using (SqlCommand command = new SqlCommand("INSERT INTO UserProfiles " +
            "VALUES(@ID, @UN, @UABOUT, @UFK_ID)", conn))
        {
            //-------------------------Commands Section
            command.Parameters.AddWithValue("@ID", profile.ProfileID);
            command.Parameters.AddWithValue("@UN", profile.Username);
            command.Parameters.AddWithValue("@UABOUT", profile.About);
            command.Parameters.AddWithValue("@UFK_ID", user.PK_EmployeeID);
            
            //int passedSave = 0;
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

            int save = await command.ExecuteNonQueryAsync();

            if (save >= 0)
            {
                Console.WriteLine($"Connection is now closed");
                conn.Close();
                return true;
            }
            else
            {
                Console.WriteLine($"Connection is now closed");
                conn.Close();
                return false;
            }

        }
    }//End Create User Profile

    public async Task<UserProfile?> Get_UserProfile(string username)
    {
        SqlConnection conn = new SqlConnection(myconnection);
        using (SqlCommand command = new SqlCommand("SELECT ProfileID, Username, About, FK_UserID from UserProfiles WHERE UserName=@UN", conn))
        {
            command.Parameters.AddWithValue("@UN", username);
            //int passedCheck = 0;

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                //Console.WriteLine($"Connection was closed and now open");
            }
            else
            {
                //Console.WriteLine($"Connection was open and now closed and open");
                conn.Close();
                conn.Open();
            }
            Console.WriteLine("\n\n\t\tAbout to read for User\n\n");
            SqlDataReader check = await command.ExecuteReaderAsync();
            UserProfile loadedUserProfile = new UserProfile();
            while (check.Read())
            {
                loadedUserProfile.ProfileID = check.GetGuid(0);
                loadedUserProfile.Username = check.GetString(1);
                loadedUserProfile.About = check.GetString(2);
                loadedUserProfile.FK_UserID = check.GetGuid(3);
                Console.WriteLine(
                    $"ID: {loadedUserProfile.ProfileID}" +
                    $"ID: {loadedUserProfile.Username}"
                    );
            }

            if (loadedUserProfile == null)
            {
                //check did not find a user that matched both credentials
                conn.Close();
                return null;
            }
            else
            {
                conn.Close();
                return loadedUserProfile;

            }
        }
    }//End of GET User Profile 

}

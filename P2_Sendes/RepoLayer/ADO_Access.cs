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
    public async Task<bool> Register_User(dynamic user)
    {
        SqlConnection conn = new SqlConnection(myconnection);
        using (SqlCommand command = new SqlCommand("INSERT INTO Users " +
            "VALUES(@ID, @UF, @UL, @UP, @UE, @UR, @USD, @UN)", conn))
        {
            //-------------------------Commands Section
            command.Parameters.AddWithValue("@ID", user.PK_UserID);
            command.Parameters.AddWithValue("@UN", user.Username);
            command.Parameters.AddWithValue("@UF", user.First);
            command.Parameters.AddWithValue("@UL", user.Last);
            command.Parameters.AddWithValue("@UP", user.Password);
            command.Parameters.AddWithValue("@UE", user.Email);
            command.Parameters.AddWithValue("@USD", user.SignupDate);
            if (user.Role == Status.User)
            {
                command.Parameters.AddWithValue("@UR", Status.User.ToString());
            }
            else if (user.Role == Status.Admin)
            {
                command.Parameters.AddWithValue("@UR", Status.Admin.ToString());
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

            if (save >= 1)
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
    public async Task<bool> CheckFor_User(string username)
    {
        Console.WriteLine($"\n\n\t\t\t{username} --- Check FOr User If Exists - ADO\n\n");
        SqlConnection conn = new SqlConnection(myconnection);
        using (SqlCommand command = new SqlCommand("SELECT UserName from Users WHERE UserName=@UN", conn))
        {
            command.Parameters.AddWithValue("@UN", username);
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
            int check = await command.ExecuteNonQueryAsync();
            Console.WriteLine($"{check} --- check result - If Exists -- ADO ");

            if (check > 0)
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

    public async Task<dynamic?> Get_User(string username)
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

            List<dynamic>? userData = new List<dynamic>();

            while (check.Read())
            {
                if (check.GetString(5) == Status.User.ToString())
                {
                    userData.Add(check.GetGuid(0));
                    userData.Add(check.GetString(7));
                    userData.Add(check.GetString(3));
                    userData.Add(check.GetString(1));
                    userData.Add(check.GetString(2));
                    userData.Add(check.GetString(4));
                    userData.Add(Status.User);
                    userData.Add(check.GetDateTime(6));
                }
                else
                {
                    userData.Add(check.GetGuid(0));
                    userData.Add(check.GetString(7));
                    userData.Add(check.GetString(3));
                    userData.Add(check.GetString(1));
                    userData.Add(check.GetString(2));
                    userData.Add(check.GetString(4));
                    userData.Add(Status.Admin);
                    userData.Add(check.GetDateTime(6));
                }
            }

            if (userData == null)
            {
                conn.Close();
                return null;
            }
            //If the userData was not an empty list 
            if (userData[6] == "User")
            {
                User user = new User(
                    userData[0],
                    userData[1],
                    userData[2],
                    userData[3],
                    userData[4],
                    userData[5],
                    userData[6],
                    userData[7]
                    );
                //check did not find a user that matched both credentials
                conn.Close();
                return user;
            }
            else
            {
                Admin user = new Admin(
                    userData[0],
                    userData[1],
                    userData[2],
                    userData[3],
                    userData[4],
                    userData[5],
                    userData[6],
                    userData[7]
                    );
                conn.Close();
                return user;

            }


        }
    }//End of GET User 


    public async Task<dynamic?> Login_User(string username, string password)
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
            List<dynamic>? userData = new List<dynamic>();

            while (check.Read())
            {
                if (check.GetString(5) == Status.User.ToString())
                {
                    userData.Add(check.GetGuid(0));
                    userData.Add(check.GetString(7));
                    userData.Add(check.GetString(3));
                    userData.Add(check.GetString(1));
                    userData.Add(check.GetString(2));
                    userData.Add(check.GetString(4));
                    userData.Add(Status.User);
                    userData.Add(check.GetDateTime(6));
                }
                else
                {
                    userData.Add(check.GetGuid(0));
                    userData.Add(check.GetString(7));
                    userData.Add(check.GetString(3));
                    userData.Add(check.GetString(1));
                    userData.Add(check.GetString(2));
                    userData.Add(check.GetString(4));
                    userData.Add(Status.Admin);
                    userData.Add(check.GetDateTime(6));
                }
            }

            if (userData == null)
            {
                conn.Close();
                return null;
            }
            //If the userData was not an empty list 
            if (userData[6] == "User")
            {
                User user = new User(
                    userData[0],
                    userData[1],
                    userData[2],
                    userData[3],
                    userData[4],
                    userData[5],
                    userData[6],
                    userData[7]
                    );
                //check did not find a user that matched both credentials
                conn.Close();
                return user;
            }
            else
            {
                Admin user = new Admin(
                    userData[0],
                    userData[1],
                    userData[2],
                    userData[3],
                    userData[4],
                    userData[5],
                    userData[6],
                    userData[7]
                    );
                conn.Close();
                return user;

            }
        }
    }//End of User Login



    public async Task<UserProfileDTO?> Create_UserProfile(UserProfile profile)
    {
        SqlConnection conn = new SqlConnection(myconnection);
        using (SqlCommand command = new SqlCommand("INSERT INTO UserProfiles " +
            "VALUES(@ID, @UN, @UABOUT)", conn))
        {
            //-------------------------Commands Section
            Console.WriteLine($"\n\n\t\tProfileID = {profile.ProfileID}\n\n");
            command.Parameters.AddWithValue("@ID", profile.ProfileID);
            command.Parameters.AddWithValue("@UN", profile.Username);
            command.Parameters.AddWithValue("@UABOUT", profile.About);
            //command.Parameters.AddWithValue("@UFK_ID", user.PK_EmployeeID);

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

            if (save > 0)//If the save was successful
            {
                Console.WriteLine($"Connection is now closed");
                conn.Close();
                UserProfileDTO newProfile = new UserProfileDTO(profile.Username, profile.About);
                return newProfile;
            }
            else
            {
                Console.WriteLine($"Connection is now closed");
                conn.Close();
                return null;
            }

        }
    }//End Create User Profile



    public async Task<List<UserProfile>?> Get_UserProfiles()
    {
        SqlConnection conn = new SqlConnection(myconnection);
        using (SqlCommand command = new SqlCommand("SELECT * FROM UserProfiles", conn))
        {
            //command.Parameters.AddWithValue("@UN", username);
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
            List<UserProfile>? profilesList = new List<UserProfile>();
            while (check.Read())
            {
                UserProfile loadedUserProfile = new UserProfile(
                    check.GetGuid(0),
                    check.GetString(1),
                    check.GetString(2)
                    );
                profilesList.Add(loadedUserProfile);
            }

            conn.Close();
            return profilesList;
        }
    }//End of GET User Profile 

}
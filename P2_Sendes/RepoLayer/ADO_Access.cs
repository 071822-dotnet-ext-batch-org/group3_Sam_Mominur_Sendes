namespace RepoLayer;
using ModelLayer;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;


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
    public async Task<dynamic?> Register_User(dynamic user)
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

            if (save > 0)
            {
                Console.WriteLine($"Connection is now closed");
                conn.Close();
                return user;
            }
            else
            {
                Console.WriteLine($"Connection is now closed");
                conn.Close();
                return null;

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
        Console.WriteLine($"\n\n\t\t\tTesting for {username} - ADO\n\n");
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
            SqlDataReader check = await command.ExecuteReaderAsync();
            List<string>? name = new List<string>();
            //while (check.Read())
            //{
            //    Console.WriteLine($"\n\n\t{check.GetString(0)} is read during the check - ADO \n");

            //    name.Add(check.GetString(0));
            //}
            if (check.Read())
            {

                //check successfully found the account with username
                Console.WriteLine($"{username} Already exists after the check - ADO ");
                conn.Close();
                return true;
            }
            else
            {
                Console.WriteLine($"{username} Does Not Exists after the check - ADO ");
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
                if (check.GetString(5) == "User")
                {
                    userData.Add(check.GetGuid(0));//id
                    userData.Add(check.GetString(1));//first
                    userData.Add(check.GetString(2));//last
                    userData.Add(check.GetString(3));//pass
                    userData.Add(check.GetString(4));//email
                    userData.Add(Status.User);//role
                    userData.Add(check.GetDateTime(6));//created
                    userData.Add(check.GetString(7));//username
                }
                else
                {
                    userData.Add(check.GetGuid(0));
                    userData.Add(check.GetString(1));
                    userData.Add(check.GetString(2));
                    userData.Add(check.GetString(3));
                    userData.Add(check.GetString(4));
                    userData.Add(Status.Admin);
                    userData.Add(check.GetDateTime(6));
                    userData.Add(check.GetString(7));
                }
            }

            if (userData != null)
            {
                //TODO add if statement of (if user or admin)
                if (userData[5] == Status.User)
                {
                    User loadedUser = new User(
                        userData[0],//id
                        userData[7],//username
                        userData[3],//pass
                        userData[1],//first
                        userData[2],//last
                        userData[4],//email
                        userData[5],//role
                        userData[6]//date
                        );
                    conn.Close();
                    return loadedUser;
                }
                else
                {
                    Admin loadedUser = new Admin(
                        userData[0],//id
                        userData[7],//username
                        userData[3],//pass
                        userData[1],//first
                        userData[2],//last
                        userData[4],//email
                        userData[5],//role
                        userData[6]//date
                        );
                    conn.Close();
                    return loadedUser;
                }
                //check did not find a user that matched both credentials
            }
            else
            {
                return null;
            }
        }
    }//End of GET User 


    public async Task<dynamic?> Login_User(UserLoginDTO user)
    {
        SqlConnection conn = new SqlConnection(myconnection);
        using (SqlCommand command = new SqlCommand("SELECT UserID, FirstName, LastName, Password, Email, Role, RegisterDate, UserName from Users WHERE UserName=@UN AND Password=@UP", conn))
        {
            command.Parameters.AddWithValue("@UN", user.Username);
            command.Parameters.AddWithValue("@UP", user.Password);
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
                if(check.GetString(5) == "User")
                {
                    userData.Add(check.GetGuid(0));//id
                    userData.Add(check.GetString(1));//first
                    userData.Add(check.GetString(2));//last
                    userData.Add(check.GetString(3));//pass
                    userData.Add(check.GetString(4));//email
                    userData.Add(Status.User);//role
                    userData.Add(check.GetDateTime(6));//created
                    userData.Add(check.GetString(7));//username
                }
                else
                {
                    userData.Add(check.GetGuid(0));
                    userData.Add(check.GetString(1));
                    userData.Add(check.GetString(2));
                    userData.Add(check.GetString(3));
                    userData.Add(check.GetString(4));
                    userData.Add(Status.Admin);
                    userData.Add(check.GetDateTime(6));
                    userData.Add(check.GetString(7));
                }
            }

            if (userData != null)
            {
                //TODO add if statement of (if user or admin)
                if (userData[5] == Status.User)
                {
                    User loadedUser = new User(
                        userData[0],//id
                        userData[7],//username
                        userData[3],//pass
                        userData[1],//first
                        userData[2],//last
                        userData[4],//email
                        userData[5],//role
                        userData[6]//date
                        );
                    conn.Close();
                    return loadedUser;
                }
                else
                {
                    Admin loadedUser = new Admin(
                        userData[0],//id
                        userData[7],//username
                        userData[3],//pass
                        userData[1],//first
                        userData[2],//last
                        userData[4],//email
                        userData[5],//role
                        userData[6]//date
                        );
                    conn.Close();
                    return loadedUser;
                }
                //check did not find a user that matched both credentials
            }
            else
            {
                return null;
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


    public async Task<List<Product>?> Get_Products()
    {
        SqlConnection conn = new SqlConnection(myconnection);
        using (SqlCommand command = new SqlCommand("SELECT ProductID, Title, Description, Price, Inventory, DateAdded, FK_UserID FROM Products", conn))
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
            Console.WriteLine("\n\n\t\tAbout to read for Products\n\n");
            SqlDataReader check = await command.ExecuteReaderAsync();
            List<Product>? productsList = new List<Product>();
            while (check.Read())
            {
                Product loadedproduct = new Product(
                    check.GetGuid(0),//id
                    check.GetString(1),//title
                    check.GetString(2),//desc
                    check.GetDecimal(3),//price
                    check.GetInt32(4),//inventory
                    check.GetDateTime(5),//created
                    check.GetGuid(6)//userID

                    //PK_ProductID = id;
                    //Title = title;
                    //Description = description;
                    //Price = price;
                    //Inventory = inventory;
                    //DateCreated = dateCreated;
                    //fk_UserID = userID;

                    );
                productsList.Add(loadedproduct);
            }

            conn.Close();
            return productsList;
        }
    }//End of GET Products


    public async Task<bool> Add_Product(Product product)
    {
        SqlConnection conn = new SqlConnection(myconnection);
        using (SqlCommand command = new SqlCommand("INSERT INTO Products " +
            "VALUES(@ID, @Title, @Descr, @Inv, @Created, @FK, @Price)", conn))
        {
            //-------------------------Commands Section
            command.Parameters.AddWithValue("@ID", product.PK_ProductID);
            command.Parameters.AddWithValue("@Title", product.Title);
            command.Parameters.AddWithValue("@Descr", product.Description);
            command.Parameters.AddWithValue("@Inv", product.Inventory);
            command.Parameters.AddWithValue("@Created", product.DateCreated);
            command.Parameters.AddWithValue("@FK", product.fk_UserID);
            command.Parameters.AddWithValue("@Price", product.Price);
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
                Console.WriteLine($"Connection is now closed - true - saved");
                conn.Close();
                //UserProfileDTO newProfile = new UserProfileDTO(profile.Username, profile.About);
                return true;
            }
            else
            {
                Console.WriteLine($"Connection is now closed - false - not saved");
                conn.Close();
                return false;
            }

        }
    }//End Create User Profile




}
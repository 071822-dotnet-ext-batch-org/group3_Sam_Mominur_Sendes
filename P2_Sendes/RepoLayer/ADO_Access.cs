namespace RepoLayer;
using ModelLayer;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;


public class ADO_Access : IADO_Access
{
    //private readonly string connection = $"Server=tcp:revature.database.windows.net,1433;Initial Catalog=Group3Project2;Persist Security Info=False;User ID=samRevature;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    private readonly IConfiguration _dbString;

    public ADO_Access(IConfiguration config)
    {
        this._dbString = config;
    }


    public async Task<List<dynamic>?> Get_ALL_USERS()
    {
        //Console.WriteLine($"\n\n\tConnection String{_dbString["ConnectionStrings: EcomProjectAPIDB"]}\n\n");
        SqlConnection conn = new SqlConnection(_dbString["ConnectionStrings:EcomProjectAPIDB"]);
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
            SqlDataReader check = await command.ExecuteReaderAsync();
            List<dynamic>? Users = new List<dynamic>();
            while (check.Read())
            {
                if (check.GetString(6) == "User")
                {
                    User user = new User(
                        
                    );
                    user.PK_UserID = check.GetGuid(0);
                    user.Username = check.GetString(1);
                    user.Password = check.GetString(2);
                    user.First = check.GetString(3);
                    user.Last = check.GetString(4);
                    user.Email = check.GetString(5);
                    user.Role = Status.User;
                    user.SignupDate = check.GetDateTime(7);
                    Users.Add(user);
                }
                else
                {
                    Admin user = new Admin(
                        
                    );
                    user.PK_UserID = check.GetGuid(0);
                    user.Username = check.GetString(1);
                    user.Password = check.GetString(2);
                    user.First = check.GetString(3);
                    user.Last = check.GetString(4);
                    user.Email = check.GetString(5);
                    user.Role = Status.Admin;
                    user.SignupDate = check.GetDateTime(7);  
                    Users.Add(user);              
                }
            }

            conn.Close();
            return Users;
        }
    }//End of GET ALL USERS

    /// <summary>
    /// Returns TRUE is saved
    /// Returns False if not saved
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<User?> Register_User(User user)
    {
        SqlConnection conn = new SqlConnection(_dbString["ConnectionStrings:EcomProjectAPIDB"]);
        using (SqlCommand command = new SqlCommand("INSERT INTO Users " +
            "VALUES(@ID, @UN, @UP, @UF, @UL, @UE, @UR, @USD )", conn))
        {
            //-------------------------Commands Section
            command.Parameters.AddWithValue("@ID", user.PK_UserID);
            command.Parameters.AddWithValue("@UN", user.Username);
            command.Parameters.AddWithValue("@UP", user.Password);
            command.Parameters.AddWithValue("@UF", user.First);
            command.Parameters.AddWithValue("@UL", user.Last);
            command.Parameters.AddWithValue("@UR", user.Role.ToString());
            command.Parameters.AddWithValue("@UE", user.Email);
            command.Parameters.AddWithValue("@USD", user.SignupDate);
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


    public async Task<dynamic?> Get_User_w_EMAIL(string Email)
    {
        SqlConnection conn = new SqlConnection(_dbString["ConnectionStrings:EcomProjectAPIDB"]);
        using (SqlCommand command = new SqlCommand("SELECT PK_UserID, Username, Password, Firstname, Lastname, Email, Role, SignUpDate from Users WHERE Email=@Email", conn))
        {
            command.Parameters.AddWithValue("@Email", Email);
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
            Console.WriteLine($"\n\n\t\tAbout to GET User for Email :{Email}\n\n");
            SqlDataReader check = await command.ExecuteReaderAsync();

            List<dynamic>? userData = new List<dynamic>();

            while (check.Read())
            {
                if (check.GetString(6) == "User")
                {
                    userData.Add(check.GetGuid(0));//id
                    userData.Add(check.GetString(1));//username
                    userData.Add(check.GetString(2));//pass
                    userData.Add(check.GetString(3));//first
                    userData.Add(check.GetString(4));//last
                    userData.Add(check.GetString(5));//email
                    userData.Add(Status.User);//role
                    userData.Add(check.GetDateTime(7));//role
                }
                else
                {
                    userData.Add(check.GetGuid(0));
                    userData.Add(check.GetString(1));
                    userData.Add(check.GetString(2));
                    userData.Add(check.GetString(3));
                    userData.Add(check.GetString(4));
                    userData.Add(check.GetString(5));
                    userData.Add(Status.Admin);
                    userData.Add(check.GetDateTime(7));
                }
            }

            if (userData != null)
            {
                //TODO add if statement of (if user or admin)
                if (userData[6] == Status.User)
                {
                    User loadedUser = new User(
                        userData[0],//id
                        userData[1],//username
                        userData[2],//pass
                        userData[3],//first
                        userData[4],//last
                        userData[5],//email
                        userData[6],//role
                        userData[7]//date
                        );
                    conn.Close();
                    return loadedUser;
                }
                else
                {
                    Admin loadedUser = new Admin(
                        userData[0],//id
                        userData[1],//username
                        userData[2],//pass
                        userData[3],//first
                        userData[4],//last
                        userData[5],//email
                        userData[6],//role
                        userData[7]//date
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
    }//End of GET User w EMAIL

    public async Task<dynamic?> Get_User_w_USERNAME(string Username)
    {
        SqlConnection conn = new SqlConnection(_dbString["ConnectionStrings:EcomProjectAPIDB"]);
        using (SqlCommand command = new SqlCommand("SELECT PK_UserID, Username, Password, Firstname, Lastname, Email, Role, SignUpDate from Users WHERE Username=@Username", conn))
        {
            command.Parameters.AddWithValue("@Username", Username);
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
            Console.WriteLine($"\n\n\t\tAbout to GET User :{Username}\n\n");
            SqlDataReader check = await command.ExecuteReaderAsync();

            List<dynamic>? userData = new List<dynamic>();

            while (check.Read())
            {
                if (check.GetString(6) == "User")
                {
                    userData.Add(check.GetGuid(0));//id
                    userData.Add(check.GetString(1));//username
                    userData.Add(check.GetString(2));//pass
                    userData.Add(check.GetString(3));//first
                    userData.Add(check.GetString(4));//last
                    userData.Add(check.GetString(5));//email
                    userData.Add(Status.User);//role
                    userData.Add(check.GetDateTime(7));//role
                }
                else
                {
                    userData.Add(check.GetGuid(0));
                    userData.Add(check.GetString(1));
                    userData.Add(check.GetString(2));
                    userData.Add(check.GetString(3));
                    userData.Add(check.GetString(4));
                    userData.Add(check.GetString(5));
                    userData.Add(Status.Admin);
                    userData.Add(check.GetDateTime(7));
                }
            }

            if (userData != null)
            {
                //TODO add if statement of (if user or admin)
                if (userData[6] == Status.User)
                {
                    User loadedUser = new User(
                        userData[0],//id
                        userData[1],//username
                        userData[2],//pass
                        userData[3],//first
                        userData[4],//last
                        userData[5],//email
                        userData[6],//role
                        userData[7]//date
                        );
                    conn.Close();
                    Console.WriteLine($"\n\n\t\tThe user :{loadedUser.Username} was GOT -- end of ADO\n\n");
                    return loadedUser;
                }
                else
                {
                    Admin loadedUser = new Admin(
                        userData[0],//id
                        userData[1],//username
                        userData[2],//pass
                        userData[3],//first
                        userData[4],//last
                        userData[5],//email
                        userData[6],//role
                        userData[7]//date
                        );
                    conn.Close();
                    Console.WriteLine($"\n\n\t\tThe user :{loadedUser.Username} was GOT -- end of ADO\n\n");
                    return loadedUser;
                }
                //check did not find a user that matched both credentials
            }
            else
            {
                Console.WriteLine($"\n\n\t\tNo user was found\n\n");
                return null;
            }
        }
    }//End of GET User w USERNAME



    public async Task<dynamic?> Login_User(UserLoginDTO user)
    {
        SqlConnection conn = new SqlConnection(_dbString["ConnectionStrings:EcomProjectAPIDB"]);
        using (SqlCommand command = new SqlCommand("SELECT PK_UserID, Username, Password, Firstname, Lastname, Email, Role, SignUpDate from Users WHERE Email=@Email AND Password=@UP", conn))
        {
            command.Parameters.AddWithValue("@Email", user.Email);
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
                if(check.GetString(6) == "User")
                {
                    userData.Add(check.GetGuid(0));//id
                    userData.Add(check.GetString(1));//username
                    userData.Add(check.GetString(2));//pass
                    userData.Add(check.GetString(3));//first
                    userData.Add(check.GetString(4));//last
                    userData.Add(check.GetString(5));//email
                    userData.Add(Status.User);//role
                    userData.Add(check.GetDateTime(7));//role
                }
                else
                {
                    userData.Add(check.GetGuid(0));//id
                    userData.Add(check.GetString(1));//username
                    userData.Add(check.GetString(2));//pass
                    userData.Add(check.GetString(3));//first
                    userData.Add(check.GetString(4));//last
                    userData.Add(check.GetString(5));//email
                    userData.Add(Status.Admin);//role
                    userData.Add(check.GetDateTime(7));//role
                }
            }

            if (userData != null)
            {
                //TODO add if statement of (if user or admin)
                if (userData[6] == Status.User)
                {
                    User loadedUser = new User(
                        userData[0],//id
                        userData[1],//username
                        userData[2],//pass
                        userData[3],//first
                        userData[4],//last
                        userData[5],//email
                        userData[6],//role
                        userData[7]//date
                        );
                    conn.Close();
                    return loadedUser;
                }
                else
                {
                    Admin loadedUser = new Admin(
                        userData[0],//id
                        userData[1],//username
                        userData[2],//pass
                        userData[3],//first
                        userData[4],//last
                        userData[5],//email
                        userData[6],//role
                        userData[7]//date
                        );
                    conn.Close();
                    Console.WriteLine($"\n\n\t\tThe user {loadedUser.Username} was found -- end of ADO");
                    return loadedUser;
                }
                //check did not find a user that matched both credentials
            }
            else
            {
                conn.Close();
                Console.WriteLine($"\n\n\t\tThe user for {user.Email} was not found -- end of ADO");
                return null;
            }
        }
    }//End of User Login



    public async Task<UserProfile?> Create_UserProfile(UserProfile profile)
    {
        SqlConnection conn = new SqlConnection(_dbString["ConnectionStrings:EcomProjectAPIDB"]);
        using (SqlCommand command = new SqlCommand("INSERT INTO Profiles " +
            "VALUES(@ID, @UABOUT,@UN )", conn))
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
                Console.WriteLine($"Connection is now closed - Saved");
                conn.Close();
                return profile;
            }
            else
            {
                Console.WriteLine($"Connection is now closed - Not Saved");
                conn.Close();
                return null;
            }

        }
    }//End Create User Profile



    public async Task<List<UserProfile>?> Get_UserProfiles()
    {
        SqlConnection conn = new SqlConnection(_dbString["ConnectionStrings:EcomProjectAPIDB"]);
        using (SqlCommand command = new SqlCommand("SELECT PK_ProfilesID, About, FK_Username FROM Profiles", conn))
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
            Console.WriteLine("\n\n\t\tAbout to read for Get all profiles\n\n");
            SqlDataReader check = await command.ExecuteReaderAsync();
            List<UserProfile>? profilesList = new List<UserProfile>();
            while (check.Read())
            {
                UserProfile loadedUserProfile = new UserProfile(
                    check.GetGuid(0),
                    check.GetString(2),
                    check.GetString(1)
                    );
                profilesList.Add(loadedUserProfile);
            }

            conn.Close();
            Console.WriteLine("\n\n\tEnd of getting user profiles\n\n");
            return profilesList;
        }
    }//End of GET User Profile

    public async Task<bool> Edit_UserProfile(UserProfileDTO profile)
    {
        SqlConnection conn = new SqlConnection(_dbString["ConnectionStrings:EcomProjectAPIDB"]);
        using (SqlCommand command = new SqlCommand("Update Profiles " +
            "Set About=@UABOUT " +
            "Where FK_Username=@Username", conn))
        {
            //-------------------------Commands Section
            command.Parameters.AddWithValue("@Username", profile.Username);
            command.Parameters.AddWithValue("@UABOUT", profile.About);

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
                Console.WriteLine($"Connection is now closed - Saved");
                conn.Close();
                return true;
            }
            else
            {
                Console.WriteLine($"Connection is now closed - Not Saved");
                conn.Close();
                return false;
            }

        }

    }


    public async Task<List<Product>?> Get_Products()
    {
        //Console.WriteLine($"\n\n\tConnection String{_dbString["ConnectionStrings: EcomProjectAPIDB"]}\n\n");
        SqlConnection conn = new SqlConnection(_dbString["ConnectionStrings:EcomProjectAPIDB"]);
        using (SqlCommand command = new SqlCommand("SELECT PK_ProductID, Title, Description, Price, Inventory, DateCreated, CreatedBy FROM Products", conn))
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
                    check.GetString(6)//userID

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
        SqlConnection conn = new SqlConnection(_dbString["ConnectionStrings:EcomProjectAPIDB"]);
        using (SqlCommand command = new SqlCommand("INSERT INTO Products " +
            "VALUES(@ID, @Title, @Descr, @Inv, @Price, @Created, @FK )", conn))
        {
            //-------------------------Commands Section
            command.Parameters.AddWithValue("@ID", product.PK_ProductID);
            command.Parameters.AddWithValue("@Title", product.Title);
            command.Parameters.AddWithValue("@Descr", product.Description);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@Inv", product.Inventory);
            command.Parameters.AddWithValue("@Created", product.DateCreated);
            command.Parameters.AddWithValue("@FK", product.CreatedBy);
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
    }//End Create a New Product

    /// <summary>
    /// Returns TRUE if username exists already
    /// --False if not
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<bool> CheckFor_User(string Email)
    {
        Console.WriteLine($"\n\n\t\t\tTesting for {Email} - ADO\n\n");
        SqlConnection conn = new SqlConnection(_dbString["ConnectionStrings:EcomProjectAPIDB"]);
        using (SqlCommand command = new SqlCommand("SELECT Email from Users WHERE Email=@Email", conn))
        {
            command.Parameters.AddWithValue("@Email", Email);
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
            if (check.Read())
            {
                //check successfully found the account with username
                Console.WriteLine($"{Email} Already exists after the check - ADO ");
                conn.Close();
                return true;
            }
            else
            {
                Console.WriteLine($"{Email} Does Not Exists after the check - ADO ");
                conn.Close();
                return false;
            }
        }
    }//End Check if User Exists by Username


    public async Task<bool> CheckFor_User_W_USERNAME(string Username)
    {
        Console.WriteLine($"\n\n\t\t\tTesting for {Username} - ADO\n\n");
        SqlConnection conn = new SqlConnection(_dbString["ConnectionStrings:EcomProjectAPIDB"]);
        using (SqlCommand command = new SqlCommand("SELECT Username from Users WHERE UserName=@Username", conn))
        {
            command.Parameters.AddWithValue("@Username", Username);
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
            if (check.Read())
            {
                //check successfully found the account with username
                Console.WriteLine($"{Username} Already exists after the check - ADO ");
                conn.Close();
                return true;
            }
            else
            {
                Console.WriteLine($"{Username} Does Not Exists after the check - ADO ");
                conn.Close();
                return false;
            }
        }
    }//End Check if User Exists by Username




}
namespace RepoLayer;
using ModelLayer;
using System.Data;
using System.Data.SqlClient;


public class ADO_Access : IADO_Access
{
    //private readonly string connection = $"Server=tcp:revature.database.windows.net,1433;Initial Catalog=Group3Project2;Persist Security Info=False;User ID=samRevature;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    private readonly string myconnection = "Server=tcp:sendesdhaiti-revature-server.database.windows.net,1433;Initial Catalog=sendesdhaiti-revature-server;Persist Security Info=False;User ID=SendesD;Password=@Arcade30;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    /// <summary>
    /// Returns TRUE is saved
    /// Returns False if not saved
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<bool> Register_User(User user)
    {
        using (SqlCommand command = new SqlCommand("INSERT INTO Users " +
            "VALUES(@ID, @UN, @UF, @UL, @UP, @UE, @UR, @USD)"))
        {
            SqlConnection conn = new SqlConnection(myconnection);
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
            int? save = null;
            //conn.Close();
            try
            {
                conn.Open();
                save = await command.ExecuteNonQueryAsync();
                Console.Write("Saving.... - RL - TRY to Register ");
            }
            catch
            {
                //throw new InvalidOperationException("something went wrong");
                Console.Write("Error occurred.");
            }
            finally
            {
                conn.Close();
            }
            if(save > 0)
            {
                //profile was saved
                return true;

            }
            return false;
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
        using(SqlCommand command = new SqlCommand("SELECT UserName from Users WHERE Username=@UN"))
        {
            SqlConnection conn = new SqlConnection(myconnection);
            command.Parameters.AddWithValue("@UN", user.Username);
            int? check = null;

            conn.Open();
            try
            {
                check = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"\n\n\t\t\tYour account is being checked now {user.Username}\n\n");

            }
            catch
            {
                Console.WriteLine("\n\n\t\t\tSomething went wrong when opening the connection and checking for username\n\n");
            }
            finally
            {
                conn.Close();
            }

            if(check > 0)
            {
                //check successfully found the account with username
                //conn.Close();
                return true;
            }
            //the account with username was not found
            //conn.Close();
            return false;



        }
    }
}

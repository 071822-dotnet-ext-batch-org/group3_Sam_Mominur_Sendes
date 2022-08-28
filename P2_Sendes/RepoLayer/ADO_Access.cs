namespace RepoLayer;
using ModelLayer;
using System.Data;
using System.Data.SqlClient;


public class ADO_Access : IADO_Access
{
    //private readonly string connection = $"Server=tcp:revature.database.windows.net,1433;Initial Catalog=Group3Project2;Persist Security Info=False;User ID=samRevature;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    private readonly string myconnection = "Server=tcp:sendesdhaiti-revature-server.database.windows.net,1433;Initial Catalog=sendesdhaiti-revature-server;Persist Security Info=False;User ID=SendesD;Password=@Arcade30;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    public async Task<dynamic> Register_User(User user)
    {
        SqlConnection conn = new SqlConnection(myconnection);
        using (SqlCommand command = new SqlCommand("INSERT INTO Users " +
            "VALUES(@ID, @UN, @UF, @UL, @UP, @UE, @UR, @USD)"))
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




            //-------------------------Connection Section
            if (conn != null && conn.State == ConnectionState.Closed)//If the connection was already closed
            {
                // open the connection
                // ...
                conn.Open();
            }
            else // if the connection was already open
            { //close the connection then open
                conn.Close();
                conn.Open();
            }




            //conn.Open();
            int saveCheck = await command.ExecuteNonQueryAsync();
            //-------------------------Results Section
            try
            {
                if (saveCheck > 0)
                {
                    //Check was successful
                    conn.Close();
                    return "Your account was saved successfully";
                }
                else
                {
                    //Check was unsuccessful
                    conn.Close();
                    return "Your account could not be saved";
                }

            }
            catch
            {
                throw new InvalidOperationException();
            }
            finally
            {
                conn.Close();
                //return "Save ended";
            }
        }
    }//--------------------End of the User Register
}

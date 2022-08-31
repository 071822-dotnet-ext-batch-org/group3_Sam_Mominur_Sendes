using Models;
using System.Data.SqlClient;

namespace RepositoryAccessLayer
{
    public class EcomRepoLayer
    {
        public async Task<List<Products>> ProductsAsync(int type)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:dbpro.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=mominur;Password=A123456789a;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Products", conn))
            {

                //command.Parameters.AddWithValue("@type", type);
                conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                List<Products> rList = new List<Products>();
                while (ret.Read())
                {
                    Products r = new Products((Guid)ret[0], (Guid)ret[1], ret.GetString(2), ret.GetString(3), ret.GetDecimal(4),ret.GetInt32(5));
                    rList.Add(r);
                }
                conn.Close();
                return rList;

            }
        }


        
        public async Task<Login> LoginAsync(Login login)
        {
        
        
            SqlConnection conn = new SqlConnection("Server=tcp:dbpro.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=mominur;Password=A123456789a;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT Email, Password FROM Users WHERE Email = @email AND Password = @password", conn))
            {

                command.Parameters.AddWithValue("@email", login.Email);
                command.Parameters.AddWithValue("@password", login.Password);
                conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();

                Login? log = null;
                if(ret.Read()){
                    log = new Login(ret.GetString(0), ret.GetString(1));
                    return log;
                }
                conn.Close();
                return null; 
            }
            
        }


         public async Task<Products>AddProductAsync(Products product)
        {
           // throw new NotImplementedException();
           
             SqlConnection conn = new SqlConnection("Server=tcp:dbpro.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=mominur;Password=A123456789a;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"INSERT INTO Products (ProductID,FK_UserID,ProductName,ProductDetails,ProductPrice,ProductInventory) VALUES(@pid,@fk,@pn,@pd,@pp,@pi);", conn))

            {
                 command.Parameters.AddWithValue("@pid", product.ProductID);
                 command.Parameters.AddWithValue("@fk", product.FK_UserID);
                 command.Parameters.AddWithValue("@pn", product.ProductName);
                 command.Parameters.AddWithValue("@pd", product.ProductDetails);
                 command.Parameters.AddWithValue("@pp", product.ProductPrice);
                 command.Parameters.AddWithValue("@pi", product.ProductInventory);
    

                conn.Open();
                int ret = await command.ExecuteNonQueryAsync();
                if (ret == 1)
                {
                    //conn.Close();
                     
                    return product;
                }

                conn.Close();
                return null;
            }

        }




    }
}
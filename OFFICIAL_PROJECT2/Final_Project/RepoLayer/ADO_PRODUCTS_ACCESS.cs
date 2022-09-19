//Required Imports
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

//My Imports
using ModelLayer;
using static ModelLayer.Models;


namespace RepoLayer
{
    public class ADO_PRODUCTS_ACCESS : IADO_PRODUCTS_ACCESS
    {
        private readonly IConfiguration _dbString;

        public ADO_PRODUCTS_ACCESS(IConfiguration config)
        {
            this._dbString = config;
        }


        /// <summary>
        /// This gets all of the products from the DB
        /// </summary>
        /// <returns></returns>
        public async Task<List<Models.Product>> GetProductsAsync()
        {
            SqlConnection conn = new SqlConnection(_dbString["_AppSecrets:ConnectionString"]);
            using (SqlCommand command = new SqlCommand("SELECT * FROM Products", conn))
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
                List<Models.Product>? Products = new List<Models.Product>();
                while (data.Read())
                {
                    Models.Product product = new Models.Product();
                    product.PK_ProductID = data.GetGuid(0);
                    product.ID = data.GetInt32(1);
                    product.Title = data.GetString(2);
                    product.Description = data.GetString(3);
                    product.Price = data.GetDecimal(4);
                    product.Inventory = data.GetInt32(5);
                    product.DateAdded = data.GetDateTime(6);
                    product.CreatedBy = data.GetString(7);
                    Products.Add(product);
                }//END WHILE
                conn.Close();
                return Products;
            }//END USING
        }//END GET ALL PRODUCTS


        /// <summary>
        /// This method saves a new product to the DB
        /// </summary>
        /// <param name="product"></param>
        /// <param name="Username"></param>
        /// <returns></returns>
        public async Task<bool> AddNewProduct(Models.FrontEnd_Product product, string Username)
        {
            SqlConnection conn = new SqlConnection(_dbString["_AppSecrets:ConnectionString"]);
            using (SqlCommand command = new SqlCommand("INSERT INTO Products " +
                " (PK_ProductID, Title, Description," +
                "Price, Inventory, DateCreated, CreatedBy)" +
                "Values(@PKID, @Title, @Descr, @Price, @Inv, @Created, @FK)", conn))
            {
                //-------------------------Commands Section
                command.Parameters.AddWithValue("@PKID", Guid.NewGuid());
                //command.Parameters.AddWithValue("@ID", product.ID=0);
                command.Parameters.AddWithValue("@Title", product.Title);
                command.Parameters.AddWithValue("@Descr", product.Description);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Inv", product.Inventory);
                command.Parameters.AddWithValue("@Created", DateTime.Now);
                command.Parameters.AddWithValue("@FK", Username);
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







    }
}


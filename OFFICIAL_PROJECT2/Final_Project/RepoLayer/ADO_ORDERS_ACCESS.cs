using System;
using Microsoft.Extensions.Configuration;
using ModelLayer;
using System.Data;
using System.Data.SqlClient;
using static ModelLayer.Models;

namespace RepoLayer
{
    public class ADO_ORDERS_ACCESS : IADO_ORDERS_ACCESS
    {
        private readonly IConfiguration _dbString;

        public ADO_ORDERS_ACCESS(IConfiguration config)
        {
            this._dbString = config;
        }


        /// <summary>
        /// This gets all of the orders from the DB
        /// </summary>
        /// <returns></returns>
        public async Task<List<Models.Order>> GetOrdersAsync()
        {
            SqlConnection conn = new SqlConnection(_dbString["_AppSecrets:ConnectionString"]);
            using (SqlCommand command = new SqlCommand("SELECT * FROM Orders", conn))
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
                List<Models.Order>? Orders = new List<Models.Order>();
                while (data.Read())
                {
                    Models.Order order = new Models.Order();
                    order.OrderID = data.GetGuid(0);
                    order.FirstName = data.GetString(1);
                    order.LastName = data.GetString(2);
                    order.Email = data.GetString(3);
                    order.StreetAddress = data.GetString(4);
                    order.City = data.GetString(5);
                    order.State = data.GetString(6);
                    order.Country = data.GetString(7);
                    order.AreaCode = data.GetInt32(8);
                    order.Total = data.GetDecimal(9);
                    order.DatePurchased = data.GetDateTime(10);
                    if (data.GetString(11) == Models.OrderStatus.Approved.ToString())
                    {
                        order.Status = Models.OrderStatus.Approved;
                    }
                    else if (data.GetString(11) == Models.OrderStatus.Bounced.ToString())
                    {
                        order.Status = Models.OrderStatus.Bounced;
                    }
                    else if (data.GetString(11) == Models.OrderStatus.Canceled.ToString())
                    {
                        order.Status = Models.OrderStatus.Canceled;
                    }
                    else if (data.GetString(11) == Models.OrderStatus.Pending.ToString())
                    {
                        order.Status = Models.OrderStatus.Pending;
                    }
                    else
                    {
                        order.Status = Models.OrderStatus.Pending;
                    }
                    Orders.Add(order);
                }//END WHILE
                conn.Close();
                return Orders;
            }//END USING
        }//END GET ALL ORDERS


        /// <summary>
        /// This method saves a new order to the DB
        /// </summary>
        /// <param name="order"></param>
        /// <param name="Username"></param>
        /// <returns></returns>
        public async Task<bool> AddNewOrder(Models.Order order)
        {
            SqlConnection conn = new SqlConnection(_dbString["_AppSecrets:ConnectionString"]);
            using (SqlCommand command = new SqlCommand("INSERT INTO Orders " +
                " (PK_OrderID, Firstname, Lastname, " +
                "Email, StreetAddress, City, State, " +
                "Country, AreaCode, Total, DatePurchased, Status) " +
                "Values(@PK_OrderID, @Firstname, @Lastname, @Email, @StreetAddress, @City, @State, " +
                "@Country, @AreaCode, @Total, @DatePurchased, @Status)", conn))
            {
                //-------------------------Commands Section
                command.Parameters.AddWithValue("@PK_OrderID", Guid.NewGuid());
                command.Parameters.AddWithValue("@Firstname", order.FirstName);
                command.Parameters.AddWithValue("@Lastname", order.LastName);
                command.Parameters.AddWithValue("@Email", order.Email);
                command.Parameters.AddWithValue("@StreetAddress", order.StreetAddress);
                command.Parameters.AddWithValue("@City", order.City);
                command.Parameters.AddWithValue("@State", order.State);
                command.Parameters.AddWithValue("@Country", order.Country);
                command.Parameters.AddWithValue("@AreaCode", order.AreaCode);
                command.Parameters.AddWithValue("@Total", order.Total);
                command.Parameters.AddWithValue("@DatePurchased", DateTime.Now);
                command.Parameters.AddWithValue("@Status", order.Status.ToString());

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
        }//End Create a New ORDER

        /// <summary>
        /// This is the method to change the status of a pending order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<bool> EditOrder(Models.Order order)
        {
            SqlConnection conn = new SqlConnection(_dbString["_AppSecrets:ConnectionString"]);
            using (SqlCommand command = new SqlCommand("Update Orders " +
                " Set Status=@Status  Where PK_OrderID=@PK_OrderID", conn))
            {
                //-------------------------Commands Section
                command.Parameters.AddWithValue("@PK_OrderID", order.OrderID);
                command.Parameters.AddWithValue("@Status", order.Status.ToString());

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
                    return true;
                }
                else
                {
                    Console.WriteLine($"Connection is now closed - false - not saved");
                    conn.Close();
                    return false;
                }

            }
        }//End EDIT ORDER

        /// <summary>
        /// This is the method to add the order products relation
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public async Task<bool> ADD_TO_ORDER_PRODUCTS_RELATION_TABLE(Guid OrderID, Guid ProductID)
        {
            SqlConnection conn = new SqlConnection(_dbString["_AppSecrets:ConnectionString"]);
            using (SqlCommand command = new SqlCommand("INSERT INTO ProductsOfOrders " +
                " Values(@Link_ID, @FK_OrderID, @FK_ProductID) ", conn))
            {
                //-------------------------Commands Section
                command.Parameters.AddWithValue("@Link_ID", Guid.NewGuid());
                command.Parameters.AddWithValue("@FK_OrderID", OrderID);
                command.Parameters.AddWithValue("@FK_ProductID", ProductID);

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
        }//END OF ORDER PRODUCTS TABLE ADD

        /// <summary>
        /// This is a method to get the list os order to product relations in the DB
        /// </summary>
        /// <returns></returns>
        public async Task<Models.ProductsOfOrder?> GetOrder_Product_RelationsAsync()
        {
            SqlConnection conn = new SqlConnection(_dbString["_AppSecrets:ConnectionString"]);
            using (SqlCommand command = new SqlCommand("Select * From  ProductsOfOrders", conn))
            {

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
                Models.ProductsOfOrder OrderRelations = new Models.ProductsOfOrder();
                List<KeyValuePair<Guid, Guid>> kVlist = new List<KeyValuePair<Guid, Guid>>();
                SqlDataReader data = await command.ExecuteReaderAsync();
                while (data.Read())
                {
                    var OrderID = data.GetGuid(1);
                    var ProdID = data.GetGuid(2);
                    KeyValuePair<Guid, Guid> orderpair = new KeyValuePair<Guid, Guid>(OrderID, ProdID);
                    kVlist.Add(orderpair);
                    var newKV = new KeyValuePair<Guid, List<KeyValuePair<Guid,Guid>>>(data.GetGuid(0), kVlist);

                    OrderRelations.ListOfRelations = newKV;

                }

                if (OrderRelations != null)//If the save was successful
                {
                    Console.WriteLine($"Connection is now closed - true - saved");
                    conn.Close();
                    //UserProfileDTO newProfile = new UserProfileDTO(profile.Username, profile.About);
                    return OrderRelations;
                }
                else
                {
                    Console.WriteLine($"Connection is now closed - false - not saved");
                    conn.Close();
                    return null;
                }

            }
        }

    }
}


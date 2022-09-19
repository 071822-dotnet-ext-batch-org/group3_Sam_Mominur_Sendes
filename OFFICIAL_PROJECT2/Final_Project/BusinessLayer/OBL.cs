using RepoLayer;
using ModelLayer;
using static ModelLayer.Models;

namespace BusinessLayer;
public class Order_BusinessLayer : IOrder_BusinessLayer
{
    private IADO_ORDERS_ACCESS _repoOrder;
    private IVerifyAnswers verify; //= new Verify_Answers();
    private IProduct_BusinessLayer _PBL;
    public Order_BusinessLayer(IADO_ORDERS_ACCESS aDO, IProduct_BusinessLayer p_BL, IVerifyAnswers vFy)
    {
        this._repoOrder = aDO;
        this.verify = vFy;
        this._PBL = p_BL;
    }



    /// <summary>
    /// This method Gets all orders from the DB using the repo
    /// </summary>
    /// <returns></returns>
    public async Task<List<Models.Order>?> GetOrdersAsync()
    {
        List<Models.Order> Orders = await this._repoOrder.GetOrdersAsync();
        return Orders;
    }//End OF GET ALL ORDERS

    /// <summary>
    /// This method Gets all order to product relations into a key-value pair of key values from the DB using the repo
    /// </summary>
    /// <returns></returns>
    public async Task<Models.ProductsOfOrder?> GetOrder_Product_RelationsAsync()
    {

        Models.ProductsOfOrder? The_ProductIDs_of_Your_Order = await this._repoOrder.GetOrder_Product_RelationsAsync();


        return The_ProductIDs_of_Your_Order;
    }//End OF GET ALL ORDERS



    /// <summary>
    /// This is the method for 
    /// </summary>
    /// <param name="Order"></param>
    /// <returns></returns>
    public async Task<bool> SendOrderCheckout(Models.FrontEnd_Order Order)
    {
        List<Models.Product> products = await this._PBL.GetProducts();
        Models.Order NewOrder = new Models.Order(
            Guid.NewGuid(),
            Order.FirstName,
            Order.LastName,
            Order.Email,
            Order.StreetAddress,
            Order.City,
            Order.State,
            Order.Country,
            Order.AreaCode,
            0,
            DateTime.Now,
            Order.ProductIDs,
            products
        );
        NewOrder.SetOrderTotal();

        if (products != null)
        {
            bool Did_Order_Send_Questionmark = await this._repoOrder.AddNewOrder(NewOrder);
            if (Did_Order_Send_Questionmark != true)
            {
                Console.WriteLine($"\n\n\t\tThe Order couldn't be saved for '{Order.FirstName} {Order.LastName}' at '{DateTime.Now}'\n\n");
                return false;
            }
            foreach (int id in Order.ProductIDs)
            {
                Models.Product product = products.Find(product => product.ID == id);
                Console.WriteLine($"\n\n\n\n\n\t\t\t\tLOGGING Product: {product.Title} for ${product.Price} at - {DateTime.Now}\n\n\t\t\t\t\tGOOD JOB TEAM\n\n\n\t\t\t\t\t");
                //Update ORDER PRODUCTS TABLE
                bool check_If_Relation_Saved = await this._repoOrder.ADD_TO_ORDER_PRODUCTS_RELATION_TABLE(NewOrder.OrderID, product.PK_ProductID);
                if (check_If_Relation_Saved != true)
                {
                    Console.WriteLine($"\n\n\t\tThe product relation for the order and its product couldnt save for '{product.Title}' at '{DateTime.Now}'\n\n");
                    return false;
                }
                Console.WriteLine($"\n\n\t\tThe product relation for the order and its product was saved for '{product.Title}' at '{DateTime.Now}'\n\n");

            }

            return true;
        }
        else
        {
            return false;
        }


    }


}

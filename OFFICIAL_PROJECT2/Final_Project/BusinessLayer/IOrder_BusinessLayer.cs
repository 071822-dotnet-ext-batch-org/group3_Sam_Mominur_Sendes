using ModelLayer;

namespace BusinessLayer
{
    public interface IOrder_BusinessLayer
    {
        Task<List<Models.Order>?> GetOrdersAsync();
        /// <summary>
        /// This method Gets all order to product relations into a key-value pair of key values from the DB using the repo
        /// </summary>
        /// <returns></returns>
        Task<Models.ProductsOfOrder?> GetOrder_Product_RelationsAsync();
        Task<bool> SendOrderCheckout(Models.FrontEnd_Order Order);
    }
}
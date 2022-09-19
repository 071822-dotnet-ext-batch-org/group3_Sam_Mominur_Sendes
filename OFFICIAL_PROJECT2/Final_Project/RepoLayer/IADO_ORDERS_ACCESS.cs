using ModelLayer;

namespace RepoLayer
{
    public interface IADO_ORDERS_ACCESS
    {
        Task<bool> AddNewOrder(Models.Order order);
        Task<List<Models.Order>> GetOrdersAsync();
        /// <summary>
        /// This is the method to change the status of a pending order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<bool> EditOrder(Models.Order order);
        /// <summary>
        /// This is the method to add the order products relation
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        Task<bool> ADD_TO_ORDER_PRODUCTS_RELATION_TABLE(Guid OrderID, Guid ProductID);
        /// <summary>
        /// This is a method to get the list os order to product relations in the DB
        /// </summary>
        /// <returns></returns>
        Task<Models.ProductsOfOrder?> GetOrder_Product_RelationsAsync();

    }
}
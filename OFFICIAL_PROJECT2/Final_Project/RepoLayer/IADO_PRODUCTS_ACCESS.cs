//Required Imports
using ModelLayer;

namespace RepoLayer
{
    public interface IADO_PRODUCTS_ACCESS
    {
        /// <summary>
        /// This gets all of the products from the DB
        /// </summary>
        /// <returns></returns>
        Task<List<Models.Product>> GetProductsAsync();
        /// <summary>
        /// This method saves a new product to the DB
        /// </summary>
        /// <param name="product"></param>
        /// <param name="Username"></param>
        /// <returns></returns>
        Task<bool> AddNewProduct(Models.FrontEnd_Product product, string Username);
    }
}
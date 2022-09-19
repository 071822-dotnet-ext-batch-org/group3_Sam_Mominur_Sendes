using ModelLayer;

namespace BusinessLayer
{
    public interface IProduct_BusinessLayer
    {
        /// <summary>
        /// This method gets all of the products using repo from DB
        /// </summary>
        /// <returns></returns>
        Task<List<Models.Product>> GetProducts();
        /// <summary>
        /// This Method creates a product using the repo to send to DB
        /// </summary>
        /// <param name="product"></param>
        /// <param name="Username"></param>
        /// <returns></returns>
        Task<bool> CreateProduct(Models.FrontEnd_Product product, string Username);
    }
}
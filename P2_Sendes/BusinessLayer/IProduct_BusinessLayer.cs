using ModelLayer;

namespace BusinessLayer
{
    public interface IProduct_BusinessLayer
    {
        Task<List<Product>?> Get_AllProducts();
        Task<Product?> Add_Product(ProductDTO productDTO);
        //Task<List<Product>?> Add_ToCart(Guid ProductID, string Username, int Quantity);
        //Task<Cart?> View_Cart(string Username);
        //Task<bool?> CheckOut_As_User(UserBase orderInfo);
        //Task<bool?> Remove_ALL_From_Cart(string Username);
        //Task<bool?> Remove_A_Product_From_Cart(Guid ProductID, string Username);
    }
}

using ModelLayer;

namespace RepoLayer
{
    public interface IADO_Access
    {
        Task<dynamic?> Register_User(dynamic user);
        Task<dynamic?> Login_User(UserLoginDTO user);
        Task<bool> CheckFor_User(string Email);
        Task<dynamic?> Get_User(string username);
        Task<UserProfileDTO?> Create_UserProfile(UserProfile profile);
        Task<List<UserProfile>?> Get_UserProfiles();
        Task<List<Product>?> Get_Products();
        Task<bool> Add_Product(Product product);
        Task<bool> Add_Product_ToCart(Guid ProductID, string Email, int Quantity);
        //Task<List<Product>?> Get_Cart(string Username);
        Task<List<Cart>?> Get_myCarts(string Username);
        Task<bool> Remove_Product_From_Cart(Guid ProductID, string Email);
        Task<bool> Remove_ALL_Products_From_Cart(string Email);
        Task<bool> Checkout_Order(Order order);
        Task<bool> Save_Order_Products_w_OrderID(Guid OrderID, Guid ProductID);
    }
}
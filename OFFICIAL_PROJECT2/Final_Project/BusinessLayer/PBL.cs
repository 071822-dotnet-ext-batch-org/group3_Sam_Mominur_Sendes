using ModelLayer;
using RepoLayer;

namespace BusinessLayer;
public class Product_BusinessLayer : IProduct_BusinessLayer
{
    private IADO_PRODUCTS_ACCESS _repoProd;
    private IVerifyAnswers verify; //= new Verify_Answers();
    public Product_BusinessLayer(IADO_PRODUCTS_ACCESS aDO, IVerifyAnswers vFy)
    {
        this._repoProd = aDO;
        this.verify = vFy;
    }

    /// <summary>
    /// This method gets all of the products using repo from DB
    /// </summary>
    /// <returns></returns>
    public async Task<List<Models.Product>> GetProducts()
    {
        List<Models.Product>? Products = await this._repoProd.GetProductsAsync();
        return Products;
    }

    /// <summary>
    /// This Method creates a product using the repo to send to DB
    /// </summary>
    /// <param name="product"></param>
    /// <param name="Username"></param>
    /// <returns></returns>
    public async Task<bool> CreateProduct(Models.FrontEnd_Product product, string Username)
    {
        dynamic check = this.verify.Verify_API_Form_Data__LongResponse(product.Title, 3, 50);
        if(check.GetType() == typeof(string))
        {
            Console.WriteLine($"\n\n\t\tThe check for the title string was: {check}\n\n");
            return false;
        }

        check = this.verify.Verify_API_Form_Data__LongResponse(product.Description, 0, 150);
        if (check.GetType() == typeof(string))
        {
            Console.WriteLine($"\n\n\t\tThe check for the title string was: {check}\n\n");
            return false;
        }

        bool check_If_Saved = await this._repoProd.AddNewProduct(product, Username);
        return check_If_Saved;


    }


}

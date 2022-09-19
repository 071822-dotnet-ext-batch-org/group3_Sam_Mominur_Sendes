using System;
using System.Diagnostics;
using ModelLayer;
using RepoLayer;

namespace BusinessLayer
{
    public class Product_BusinessLayer : IProduct_BusinessLayer
    {
        private readonly IADO_Access _repoLayer;
        //private readonly VerifyAnswers verify;
        //private readonly VerifyAnswers verify;
        //public Product_BusinessLayer() { }
        public Product_BusinessLayer(IADO_Access repoLayer)
        {
            this._repoLayer = repoLayer;

        }


        //______________Start BL Section

        public async Task<List<Product>?> Get_AllProducts()
        {
            List<Product>? products = await this._repoLayer.Get_Products();
            return products;
        }//End of List all product

        public async Task<Product?> Add_Product(ProductDTO productDTO)
        {
            VerifyAnswers answers = new VerifyAnswers();

            //Get user ID
            Product product = new Product(
                Guid.NewGuid(),
                productDTO.Title,
                productDTO.Description,
                productDTO.Price,
                productDTO.Inventory,
                DateTime.Now,
                productDTO.User

                );
            bool savedProduct = await this._repoLayer.Add_Product(product);
            if(savedProduct == true)
            {
                return product;
            }
            else
            {
                return null;
            }
        }//End of get all products

        //public async Task<List<Product>?> Add_ToCart(Guid ProductID, string Email, int Quantity)
        //{
        //    //get the username
        //    dynamic? cartUser = await this._repoLayer.Get_User(Email);
        //    Console.WriteLine($"\n\n\tCart of User: {cartUser.Username}\n\n");
        //    if(cartUser != null)
        //    {
        //        bool check = await this._repoLayer.Add_Product_ToCart(ProductID, cartUser.Email, Quantity);
        //        if(check == true)
        //        {
        //            //Get the list of products
        //            List<Cart>? userCart = await this._repoLayer.Get_myCarts(Email);
        //            List<Product> products = new List<Product>();
        //            foreach(Cart i in userCart)
        //            {
        //                products.Add(i?._Cart.Find(x => x.CreatedBy == cartUser.));
        //            }
        //            return products;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}//End of Add to Cart

        //public async Task<bool?> Remove_ALL_From_Cart(string Email)
        //{//Username should already be verified
        //    if(Email != null)
        //    {
        //        bool removed = await this._repoLayer.Remove_ALL_Products_From_Cart(Email);
        //        if(removed == true)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}//End of Remove all from cart

        //public async Task<bool?> Remove_A_Product_From_Cart(Guid ProductID, string Email)
        //{//Username should already be verified
        //    if (Email != null)
        //    {
        //        bool removed = await this._repoLayer.Remove_Product_From_Cart(ProductID, Email);
        //        if (removed == true)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}//End of Remove single product from cart

        //public async Task<Cart?> View_Cart(string Email)
        //{
        //    List<Product>? products = await this._repoLayer.Get_Products();
        //    List<Cart>? userCarts = await this._repoLayer.Get_myCarts(Email);
        //    //Get the product in each cart and add that product to the list of products in this one cart
        //    Cart? myCart = new Cart();
        //    myCart.CartUser = Email;
            
        //    if(userCarts != null)
        //    {
        //        if(products != null)
        //        {
        //            foreach (Cart? cart in userCarts)
        //            {
        //                myCart.Quanity += cart.Quanity;
        //                myCart._Cart?.Add(products.Find(x => x.PK_ProductID == cart.FK_Product));
        //            }
        //        }
        //        return myCart;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}//End of View Cart by username


        //public async Task<Cart?> View_Cart_by_Email(string email)
        //{
        //    List<Product>? products = await this._repoLayer.Get_Products();
        //    List<Cart>? userCarts = await this._repoLayer.Get_myCarts_By_Email(email);
        //    //Get the product in each cart and add that product to the list of products in this one cart
        //    Cart? myCart = new Cart();
        //    myCart.CartUser = email;

        //    if (userCarts != null)
        //    {
        //        if (products != null)
        //        {
        //            foreach (Cart? cart in userCarts)
        //            {
        //                myCart.Quanity += cart.Quanity;
        //                myCart._Cart?.Add(products.Find(x => x.PK_ProductID == cart.FK_Product));
        //            }
        //        }
        //        return myCart;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}//End of View Cart by Email


        //public async Task<bool?> CheckOut_As_User(UserBase orderInfo)
        //{
        //    if(orderInfo.Email != null)
        //    {
        //        Cart? myCart = await View_Cart(orderInfo.Email);
        //        if(myCart == null)
        //        {
        //            return null;
        //        }//If Cart is empty
        //        else
        //        {
        //            //TODO -- Make an order containing the product details dto and order details
        //            Order newOrder = new Order(
        //                orderInfo.First,
        //                orderInfo.Last,
        //                orderInfo.Email
        //                );
        //            newOrder.UserCart = myCart;

        //            bool checkedOut = await this._repoLayer.Checkout_Order(newOrder);
        //            if(checkedOut == true)
        //            {
        //                //If checkout was true, add the orderID and each bought product to the table
        //                decimal OrderTotal = 0;
        //                foreach(Product p in myCart._Cart)
        //                {
        //                    bool savedToOrder = await this._repoLayer.Save_Order_Products_w_OrderID(newOrder.OrderID, p.PK_ProductID);
        //                    Console.WriteLine($"\n\t\tThe product '{p.Title}' with id: '{p.PK_ProductID}' has been returned as - {savedToOrder}");
        //                }
        //                bool removeProd = await this._repoLayer.Remove_ALL_Products_From_Cart(newOrder.Email);
        //                if (removeProd == true)
        //                {
        //                    //Checkout was processed and all products removed from cart
        //                    return true;
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //            else
        //            {
        //                return false;
        //            }

        //        }//You have things in your cart
        //    }
        //    return null;

        //}//End of checkout

    }
}


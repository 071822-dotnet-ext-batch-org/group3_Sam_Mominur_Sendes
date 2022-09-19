using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

//Imported
using System.ComponentModel.DataAnnotations;
using System.Globalization;

//My Imports
using ModelLayer;
using BusinessLayer;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Final_Project.Controllers
{
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private IProduct_BusinessLayer PBL;
        private IUser_BusinessLayer UBL;
        private IOrder_BusinessLayer OBL;
        private IVerifyAnswers verify;
        public OrderController(IOrder_BusinessLayer o_BL, IProduct_BusinessLayer p_BL, IUser_BusinessLayer u_BL, IVerifyAnswers ver)
        {
            this.OBL = o_BL;
            this.PBL = p_BL;
            this.UBL = u_BL;
            this.verify = ver;
        }

        /// <summary>
        /// This is the controller to get all the orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Models.Order>>> GetOrders()
        {
            List<Models.Order>? Orders = await this.OBL.GetOrdersAsync();
            return Ok(Orders);

        }//END GET ORDERS


        /// <summary>
        /// This is the controller to get all the orders
        /// </summary>
        /// <returns></returns>
        [HttpGet("ALLPRODUCTRELATIONS")]
        public async Task<ActionResult<Models.ProductsOfOrder?>> GetOrderRelationTO_Products()
        {
            Models.ProductsOfOrder? OrderRelations = await this.OBL.GetOrder_Product_RelationsAsync();
            return Ok(OrderRelations);

        }//END GET ORDERS

        /// <summary>
        /// This is the controller to checkout
        /// </summary>
        /// <param name="order"></param>
        /// <param name="productIDs"></param>
        /// <returns></returns>
        [HttpPost("Checkout")]
        public async Task<ActionResult<string>> Checkout(Models.FrontEnd_Order order, int[] productIDs)
        {
            if (ModelState.IsValid)
            {
                bool check = this.verify.Veryify_EMAIL(order.Email);
                if(check != true)
                {
                    return Conflict($"Your email '{order.Email}' was not valid!");
                }

                check = this.verify.Verify_API_Form_Data__StringsONLY(order.FirstName, 3, 50);
                if(check != true)
                {
                    return Conflict($"Your first name '{order.LastName}' was not valid!");
                }

                check = this.verify.Verify_API_Form_Data__StringsONLY(order.LastName, 3, 50);
                if (check != true)
                {
                    return Conflict($"Your first name '{order.Email}' was not valid!");
                }

                bool Did_Order_Send = await this.OBL.SendOrderCheckout(order);
                if(Did_Order_Send != true)
                {
                    return Conflict("Your order could not be processed.");
                }
                else
                {
                    return Ok("Your order has been placed");
                }
            }
            else
            {
                return BadRequest("Your order could not go through!");
            }
        }//END OF CHECKOUT

    }
}


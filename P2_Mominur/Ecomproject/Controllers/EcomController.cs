using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using BusinessLayer;
namespace Ecomproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcomController : ControllerBase
    {

        private readonly EcomBusinessLayer _businessLayer;
        public EcomController()
        {
            //this._businessLayer = new BusinessLayer();
            this._businessLayer = new EcomBusinessLayer();


        }


        [HttpGet("ProductsAsync")]  // get all requests
        public async Task<ActionResult<List<Products>>>ProductsAsync(int type)
        {
            List<Products> requestList = await this._businessLayer.ProductsAsync(type);
            return Ok(requestList);
        }

        [HttpPost("LoginAsync")]
        public async Task<ActionResult<Login>> LoginAsync( Login login)
        {
            if (ModelState.IsValid)
            { 
            // Send the ApprivalDto to business layer
             Login loginTask = await this._businessLayer.LoginAsync(login);
            return Ok( loginTask);
              }
             else return Conflict(login);//StatusCode(StatusCodes.Status409Conflict);
        }


        [HttpPost("AddProductAsync")]
        public async Task<ActionResult<Products>>AddProductAsync( Products product)
        {
            if (ModelState.IsValid)
            { 
            // Send the ApprivalDto to business layer
             Products addProduct = await this._businessLayer.AddProductAsync(product);
            return Ok(addProduct);
              }
             else return Conflict(product);//StatusCode(StatusCodes.Status409Conflict);
        }

 

    }
}

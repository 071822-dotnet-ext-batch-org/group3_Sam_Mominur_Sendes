 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eproject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EprojectController : ControllerBase
    {
        
        [HttpGet("ProductsAsync")]
        public async ActionResult<List<Products>> ProductsAsync()
     
             {

             }
       
    }
}
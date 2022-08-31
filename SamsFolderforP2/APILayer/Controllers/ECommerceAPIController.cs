using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ECommerceAPIController : ControllerBase
    {
        private readonly Business _businessLayer;
        public ECommerceAPIController()
        {
            this._businessLayer = new Business();
        }
        
        /// <summary>
        /// #1 Login as an Admin or User by using Username and Password
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<ActionResult<List<LoginDto>>> LoginAsync(LoginDto login)
        {
            if (ModelState.IsValid)
            {
                LoginDto loginDto = await this._businessLayer.LoginAsync(login);
                return Ok(loginDto);
            }
            else return Conflict(login);
        }
    }
}

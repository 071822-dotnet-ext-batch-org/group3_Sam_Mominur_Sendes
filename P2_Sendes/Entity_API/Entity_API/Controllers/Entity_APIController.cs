using System;
using Microsoft.AspNetCore.Mvc;
//using Entity_API.Models.User;
//using Model.User as User;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Entity_API
{
    [ApiController]
    [Route("[controller]")]
    public class Entity_APIController : ControllerBase
    {
        //private readonly Model.User as User;
        private static List<Model.User> Users = new List<Model.User>()
        {
            new Model.User
            {
                Id = Guid.NewGuid(),
                Username = "Sendes",
                Password = "Pass1",
                FirstName = "Test",
                LastName = "User",
                Role = Model.Status.User,
                Email = "ex@email.com",
                SignUpDate = DateTime.Now


            }
        };
        // GET: /<controller>/

        [HttpGet]
        public ActionResult<List<Model.User>>? GetUsers()
        {
            if(Users != null)
            {
                return Ok(Users);
            }
            else
            {
                return Ok(null);
            }
        }
    }
}


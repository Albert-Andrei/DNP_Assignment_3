using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assigment_No3._0.Data;
using Assigment_No3._0.Model;
using Microsoft.AspNetCore.Mvc;

namespace Assigment_No3._0.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetResponse([FromQuery] string? username, [FromQuery] string? password)
        {
            try
            {
                userService.ValidateUser(username,password);
                Console.Out.WriteLine(userService.ValidateUser(username,password));
                return Ok(userService.ValidateUser(username,password));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
       
    }
}
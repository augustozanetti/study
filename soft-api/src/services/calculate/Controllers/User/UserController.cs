using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace calculate.Controllers
{
    [ApiController]
    [Route("api/showmethecode")]
    public class UserController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet()]
        public string ShowMeTheCode()
        {
            return this._configuration.GetSection("GITHUB_URL").Value;
        }
    }
}

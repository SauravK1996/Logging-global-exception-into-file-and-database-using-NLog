using System;
using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return Content("Hello World from home");
        }

        [HttpGet]
        public IActionResult AppError()
        {
            throw new Exception("Let's log the exception");
        }
    }
}
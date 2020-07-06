using System;
using AccountOwnerServer.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ServiceFilter(typeof(DblExceptionFilter))]
    public class BaseController : ControllerBase
    {
        
        public IActionResult Index()
        {
            return Content("Hello World from base");
        }

        [HttpGet]
        public IActionResult AppError()
        {
            throw new Exception("Let's log the exception");
        }
    }
}
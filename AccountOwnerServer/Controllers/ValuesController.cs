using System;
using AccountOwnerServer.Filters;
using Contracts;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AccountOwnerServer.Controllers
{
    [ServiceFilter(typeof(LogFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ILoggerManager _logger;
        //private ILogger<ValuesController> _logger;
        //public ValuesController(ILogger<ValuesController> logger)
        public ValuesController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //using try-catch-block

            //try
            //{
            //    _logger.LogInfo("Fetching all the Students from the storage");

            //    var students = DataManager.GetAllStudents(); //simulation for the data base access

            //    throw new Exception("Exception while fetching all the students from the storage.");

            //    _logger.LogInfo($"Returning {students.Count} students.");

            //    return Ok(students);
            //}
            //catch(Exception ex)
            //{
            //    _logger.LogError($"Somethings went wrong: {ex}");
            //    return StatusCode(500, "Internal server error");
            //}


            //using built-in exception

            _logger.LogInfo("Fetching all the Students from the storage");
            //_logger.LogCritical("nlog is working from values controller");

            var students = DataManager.GetAllStudents(); //simulation for the data base access

            throw new Exception("Exception while fetching all the students from the storage.");

            //_logger.LogInfo($"Returning {students.Count} students.");

            //return Ok(students);
            
        }
    }
}
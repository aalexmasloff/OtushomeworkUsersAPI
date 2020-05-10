using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Otushomework.Users.API.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<HealthController> _logger;
        private readonly IConfiguration _configuration;

        public HealthController(ILogger<HealthController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("health")]
        public IActionResult Get()
        {
            return Ok(new {result = "OK"});
        }

        [HttpGet]
        [Route("env")]
        public IActionResult GetEnv()
        {
            var connStr = Startup.BuildConnectionString(_configuration);
            return Ok(connStr + " v0.1");
        }

        //[HttpGet]
        //[Route("echo")]
        //public IActionResult GetEcho([FromQuery]dynamic model)
        //{
        //    return Ok(model);
        //}

        //[HttpPost]
        //[Route("echo")]
        //public IActionResult PostEcho([FromBody]dynamic model)
        //{
        //    return Ok(model);
        //}
    }
}

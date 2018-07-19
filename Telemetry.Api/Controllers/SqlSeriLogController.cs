using Microsoft.AspNetCore.Mvc;
using System;

namespace Telemetry.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/SqlSeriLog")]
    public class SqlSeriLogController : Controller
    {
        private readonly Serilog.ILogger _logger;
        public SqlSeriLogController(Serilog.ILogger logger)
        {
            _logger = logger;
        }

        public IActionResult Get()
        {
            _logger.Error("Data Critical Added Successfully");
            _logger.Fatal("Data Error Added Successfully");
            _logger.Error("Data saved as information {@DateTime}", DateTime.Now);
            return Ok("Success");
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using Contracts.DataTransferObjects;
using Contracts.Services;
using Common;

namespace WebApi.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class PathFindingAlgorithmsController : ControllerBase {
        private readonly IAlgorithmExecutor _executor;
        public PathFindingAlgorithmsController(IAlgorithmExecutor executor) {
            _executor = executor;
        }

        [HttpPost]
        public ActionResult Execute([FromBody] Grid grid) {
            try {
                return Ok(_executor.Execute(grid));
            }
            catch (Exception) {
                return BadRequest();
            }
        }

    }
}
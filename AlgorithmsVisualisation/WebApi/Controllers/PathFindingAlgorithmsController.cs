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


        [HttpPost("{type:int}")]
        public ActionResult Execute(int type, [FromBody] Grid grid) {
            try {
                if (!Enum.IsDefined(typeof(AlgorithmType), type))
                    return NotFound();
                return Ok(_executor.Execute(grid, (AlgorithmType)type));
            }
            catch (Exception) {
                return BadRequest();
            }
        }

    }
}
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
        public async Task<ActionResult> Execute([FromBody] Grid grid) {
            try {
                if (!ModelState.IsValid)
                    return BadRequest();

                return Ok(await _executor.Execute(grid));
            }
            catch (Exception) {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("test/{testCount:int}")]
        public async Task<ActionResult> TestAlgorithmsExecute([FromBody] Grid grid, int testCount) {
            try {
                if (!ModelState.IsValid)
                    return BadRequest();

                return Ok(await _executor.TestExecute(grid, testCount));
            }
            catch (Exception) {
                return BadRequest();
            }
        }

    }
}
using Microsoft.AspNetCore.Mvc;
using MoLSP.Api.Models;
using MoLSP.Api.Services;
using Microsoft.AspNetCore.Authorization;

namespace MoLSP.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LookupGroupController : ControllerBase
    {
        private readonly LookupGroupService _service;

        public LookupGroupController(LookupGroupService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEdit([FromBody] LookupGroup group)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool success = await _service.AddOrEditLookupGroupAsync(group);
            return success ? Ok("Saved successfully.") : StatusCode(500, "An error occurred.");
        }
    }
}

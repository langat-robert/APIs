using CSharpSample1.API.Models;
using CSharpSample1.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSharpSample1.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LookupGroupController : ControllerBase
    {
        private readonly LookupGroupService _service;
        public LookupGroupController(LookupGroupService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEdit([FromBody] LookupGroupDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.AddOrEditLookupGroupAsync(dto);
            if (result >= 0)
                return Ok(new { Success = true });
            return StatusCode(500, "Failed to add or edit lookup group.");
        }
    }
}

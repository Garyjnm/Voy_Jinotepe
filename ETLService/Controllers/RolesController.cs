using Microsoft.AspNetCore.Mvc;
using Operations.Roles;

namespace ETLService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRoles()
        {
            var entity = new Roles();
            var roles = entity.Where<Roles>();
            return Ok(roles);
        }
    }
}
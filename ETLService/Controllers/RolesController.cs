using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Operations.Roles;

namespace ETLService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult GetRoles()
        {
            var entity = new Roles();
            var roles = entity.Where<Roles>();
            return Ok(roles);
            
        }
    }
}
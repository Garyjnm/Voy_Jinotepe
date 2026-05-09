using Microsoft.AspNetCore.Mvc;
using Operations.Usuarios;
using APPCORE;

namespace ETLService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetUsers()
        {
            List<Users> usuarios = new Users().Get<Users>();;
            try
            {
                if (usuarios == null || usuarios.Count == 0)
                {
                    return NotFound();
                }
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<UserDto> GetById(int id)
        {
            try
            {
                var entity = new Users();
                var user = entity.Find<Users>(
                    FilterData.Equal("id_usuario", id)
                );

                if (user == null) return NotFound();

                return Ok(new UserDto
                {
                    id_usuario = user.id_usuario ?? 0,
                    username = user.username ?? "",
                    id_rol = user.id_rol ?? 0
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
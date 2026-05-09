using Microsoft.AspNetCore.Mvc;
using ETLService.Models;
using Operations.Users;
using APPCORE;

namespace ETLService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // GET: /api/users
        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetUsers()
        {
            var entity = new Users();

            System.Console.WriteLine(entity);
            // Esto consulta TODOS los registros
            var usuarios = entity.Where<Users>();

            return Ok(usuarios);
        }


        // GET: /api/users/5
        [HttpGet("{id:int}")]
        public ActionResult<UserDto> GetById(int id)
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
    }
}
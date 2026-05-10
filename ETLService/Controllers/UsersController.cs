using Microsoft.AspNetCore.Mvc;
using Operations.Users;
using ETLService.Security;
using APPCORE;

namespace ETLService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // GET: /api/users
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            var entity = new Users();
            var users = entity.Where<Users>(); 

            var result = users.Select(u => new UserDto
            {
                id_usuario = u.id_usuario ?? 0,
                username = u.username ?? "",
                id_rol = u.id_rol ?? 0
            });

            return Ok(result);
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

        [HttpPost]
        public IActionResult CreateUser([FromBody] RegisterUserDto dto)
        {
            // Verifica que el usuario no exista
            var usersEntity = new Users();
            var existing = usersEntity.Find<Users>(FilterData.Equal("username", dto.username));
            if (existing != null)
                return Conflict("Usuario ya existe.");

            // 1. Hashea la contraseña recibida
            string hash = PasswordHasher.Hash(dto.password);

            // 2. Crea el objeto Users con el hash
            var nuevo = new Users
            {
                username = dto.username,
                password = hash,
                id_rol = dto.id_rol
            };

            // 3. Guarda en la base con AppCore
            nuevo.Save();

            return Ok("Usuario creado exitosamente");
        }
    }
}
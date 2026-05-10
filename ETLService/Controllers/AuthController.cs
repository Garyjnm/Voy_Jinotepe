using Microsoft.AspNetCore.Mvc;
using Operations.Users; 
using ETLService.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using APPCORE;  

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest dto)
    {
        // 1. Buscar usuario en la BD
        var usersEntity = new Users();
        var user = usersEntity.Find<Users>(
            FilterData.Equal("username", dto.username)
        );
        if (user == null) return Unauthorized();

        // 2. Verificar password usando hash
        if (!PasswordHasher.Verify(dto.password, user.password!))
            return Unauthorized();

        // 3. Generar JWT
       var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.id_usuario!.ToString()!),
            new Claim(ClaimTypes.Name, user.username!),
        };

        // Obtenemos la llave del appsettings.json
        var secretKey = _configuration["Jwt:Key"]; 

        if (string.IsNullOrEmpty(secretKey)) 
            throw new Exception("La llave JWT no está configurada en appsettings.json");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: creds
        );
        
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(new { token = tokenString });
    }

    public class LoginRequest
    {
        public string username { get; set; } = "";
        public string password { get; set; } = "";
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Operations.Categories;
using APPCORE;

namespace ETLService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        [Authorize(Roles = "admin, user")]
        [HttpGet]
        public IActionResult GetRoles()
        {
            var entity = new Categorias();
            var roles = entity.Where<Categorias>();
            return Ok(roles);
            
        }

        [Authorize(Roles = "admin, user")]
        [HttpGet("{id:int}")]
        public ActionResult<Categorias> GetById(int id)
        {
            var entity = new Categorias();

            var category = entity.Find<Categorias>(
                FilterData.Equal("id_categoria", id)
            );

            if (category == null) return NotFound();

            return Ok(category);
        }
    }
}
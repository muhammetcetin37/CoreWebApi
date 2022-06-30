using HttpStatusCode.Infrastructure.Repository.Abstract;
using HttpStatusCode.Models.DTOs.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HttpStatusCode.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryDAL categoryDAL;

        public CategoryController(ICategoryDAL categoryDAL)
        {
            this.categoryDAL = categoryDAL;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var result = categoryDAL.FindAll();
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var category = categoryDAL.Find(Id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }
        }
        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category input)
        {
            if (input == null)
            {
                return BadRequest();
            }
            var sonuc = categoryDAL.CheckName(input.Name);
            if (sonuc == null)
            {
                ModelState.AddModelError("", $"Bu{input.Name} İsminde bir kategori vardir");
                return StatusCode(406);
            }
            categoryDAL.Add(input);
            return Ok(input);
        }

    }
}

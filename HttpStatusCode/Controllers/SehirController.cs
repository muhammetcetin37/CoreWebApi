using HttpStatusCode.Infrastructure.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HttpStatusCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SehirController : ControllerBase
    {
        private readonly ISehirDAL sehirDAL;

        public SehirController(ISehirDAL sehirDAL)
        {

            this.sehirDAL = sehirDAL;
        }
        [HttpGet]
        public IActionResult GetSehirler()
        {
            var sonuc = sehirDAL.FindAll();
            if (sonuc != null)
            {
                return Ok(sonuc);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

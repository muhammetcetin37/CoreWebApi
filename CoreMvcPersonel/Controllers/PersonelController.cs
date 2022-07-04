using CoreMvcPersonel.Models.Contexts;
using CoreMvcPersonel.Models.DTOs.PersonelDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreMvcPersonel.Controllers
{
    public class PersonelController : Controller
    {
        private readonly SqlContext sqlContext;


        public PersonelController(SqlContext sqlContext)
        {
            this.sqlContext = sqlContext;
        }
        public IActionResult Index()
        {
            var sonuc = sqlContext.
                       Personeller.Include(p => p.Adresler)
                                  .Include(p => p.Fotograflar).ToList();
            return View(sonuc);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var personel = new PersonelCreateDTO();
            return View(personel);
        }
    }
}

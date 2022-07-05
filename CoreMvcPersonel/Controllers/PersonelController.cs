using CoreMvcPersonel.Models.Contexts;
using CoreMvcPersonel.Models.DTOs.PersonelDTOs;
using CoreMvcPersonel.Models.Entities;
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
            var sonuc = sqlContext
                .Personeller.Include(p => p.Adresler)
                            .Include(p => p.Fotograflar).ToList();

            return View(sonuc);
        }

        public IActionResult Create()
        {
            var personel = new PersonelCreateDTO();

            return View(personel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(PersonelCreateDTO dTO)
        {
            if (ModelState.IsValid)
            {
                Personel personel = new();

                Fotograf fotograf = new Fotograf();
                using (var memoryStram = new MemoryStream())
                {
                    await dTO.PhotoUrl.CopyToAsync(memoryStram);
                    if (memoryStram.Length < 2097152) // 2 mb 'dan kucuk ise
                    {
                        fotograf.Foto = memoryStram.ToArray();

                    }
                }
                personel.Ad = dTO.Ad;
                personel.Soyad = dTO.Soyad;
                personel.TcNo = dTO.TcNo;
                personel.Email = dTO.Email;
                personel.Gsm = dTO.Gsm;
                personel.Fotograflar = new List<Fotograf>();
                personel.Fotograflar.Add(fotograf);
                sqlContext.Personeller.Add(personel);
                sqlContext.SaveChanges();
            }
            return View();
        }
    }
}
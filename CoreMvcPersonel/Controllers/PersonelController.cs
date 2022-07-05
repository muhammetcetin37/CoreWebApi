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
        private readonly IWebHostEnvironment hostEnvironment;

        public PersonelController(SqlContext sqlContext, IWebHostEnvironment hostEnvironment)
        {
            this.sqlContext = sqlContext;
            this.hostEnvironment = hostEnvironment;
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
        public IActionResult Create(PersonelCreateDTO dTO)
        {
            if (ModelState.IsValid)
            {
                Personel p = new Personel();
                p.Ad = dTO.Ad;
                p.Soyad = dTO.Soyad;
                p.Email = dTO.Email;
                p.TcNo = dTO.TcNo;
                p.Gsm = dTO.Gsm;
                p.Fotograflar = new List<Fotograf>();
                p.Adresler = new List<Adres>();
                Adres yeniAdres = new Adres
                {
                    SehirId = dTO.Adres.SehirId,
                    IlceId = dTO.Adres.IlceId,
                    AdresTip = AdresTip.Ev
                };
                p.Adresler.Add(yeniAdres);

                #region Fotograf işlemleri
                Fotograf foto = new Fotograf();

                //projenin çalıştıgı wwwroot klasorunun yolunu verir
                string wwwrootPath = hostEnvironment.WebRootPath;

                //kullanıcıdan gelen dosya ismi
                string fileName = Path.GetFileNameWithoutExtension(dTO.PhotoUrl.FileName);

                //diger dosyalar ile karışmasın diye verdigimiz tarih formatı
                fileName += DateTime.Now.ToString("yymmddhhmmss") + Path.GetExtension(dTO.PhotoUrl.FileName);
                foto.Path = Path.Combine(wwwrootPath, fileName);

                //oluşturulan dosyanın verilen path e yazılması
                using (var fileStream = new FileStream(foto.Path, FileMode.CreateNew))
                {
                    dTO.PhotoUrl.CopyTo(fileStream);
                }

                #endregion


            }


            return View(dTO);
        }
    }
}
using CoreMvcPersonel.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace CoreMvcPersonel.Models.DTOs.PersonelDTOs
{
    public class PersonelCreateDTO
    {
        [Required(ErrorMessage = "Isim Alani zorunludur")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Soyad Alani zorunludur")]
        public string Soyad { get; set; }
        public string? TcNo { get; set; }
        public string? Email { get; set; }
        public string? Gsm { get; set; }

        public Adres? Adres { get; set; }
        public Fotograf? Fotograf { get; set; }
    }
}

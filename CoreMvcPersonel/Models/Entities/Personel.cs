namespace CoreMvcPersonel.Models.Entities
{
    public class Personel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TcNo { get; set; }
        public string? Email { get; set; }
        public string? Gsm { get; set; }
        public ICollection<Adres>? Adresler { get; set; }

        public ICollection<Fotograf>? Fotograflar { get; set; }
    }
}

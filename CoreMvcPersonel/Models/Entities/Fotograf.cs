namespace CoreMvcPersonel.Models.Entities
{
    public class Fotograf
    {
        public int Id { get; set; }
        public string? Path { get; set; }
        public byte[]? Foto { get; set; }
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }
    }
}
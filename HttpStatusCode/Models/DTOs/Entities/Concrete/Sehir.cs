using HttpStatusCode.Models.DTOs.Entities.Abstract;

namespace HttpStatusCode.Models.DTOs.Entities.Concrete
{
    public class Sehir : BaseEntity
    {
        public string SehirAdi { get; set; }
        public ICollection<Ilce> Ilce { get; set; }
    }
}

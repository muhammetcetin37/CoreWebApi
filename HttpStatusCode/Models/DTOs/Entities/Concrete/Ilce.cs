using HttpStatusCode.Models.DTOs.Entities.Abstract;

namespace HttpStatusCode.Models.DTOs.Entities.Concrete
{
    public class Ilce : BaseEntity
    {
        public string IlceAdi { get; set; }
        public int SehirId { get; set; }
        public Sehir Sehir { get; set; }

    }
}

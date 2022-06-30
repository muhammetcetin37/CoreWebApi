using HttpStatusCode.Models.DTOs.Entities.Abstract;

namespace HttpStatusCode.Models.DTOs.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

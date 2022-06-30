using HttpStatusCode.Infrastructure.Repository.Abstract;
using HttpStatusCode.Models.DTOs.Entities.Concrete;

namespace HttpStatusCode.Infrastructure.Repository.Concrete
{
    public class CategoryDAL : RepositoryBase<Category>, ICategoryDAL
    {
        public bool CheckName(string name)
        {
            var sonuc = base.FindAll(p => p.Name == name);
            if (sonuc.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

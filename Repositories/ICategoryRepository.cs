using WebsiteBanHangOMon.Models;

namespace WebsiteBanHangOMon.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebsiteBanHangOMon.Models;
using WebsiteBanHangOMon.Repositories;

namespace WebsiteBanHangOMon.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository,
    ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Add()
        {
            var categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(product);
                return RedirectToAction("Index"); // Chuyển hướng tới trang danh sách sản phẩm
            }
            return View(product);
        }


        public IActionResult Index()
        {
            // Danh sach sản phẩm 
            var products = _productRepository.GetAll();
            return View(products); // truyền dữ liệu qua view 
        }
    }
}

using COMP003.LectureActivity5.Data;
using COMP003.LectureActivity5.Models;

using Microsoft.AspNetCore.Mvc;

namespace COMP003.LectureActivity5.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        [HttpGet]

        public ActionResult<List<Product>> GetProducts()
        {
            return Ok(ProductStore.Products);
        }

        [HttpGet("{id}")]

        public ActionResult<Product> GetProduct(int id)
        {
            var product = ProductStore.Products.FirstOrDefault(p => p.Id == id);

            if (product is null)
                return NotFound();

            return Ok(product);
        }
    }
}

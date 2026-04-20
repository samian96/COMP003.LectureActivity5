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

        [HttpPost]

        public ActionResult<Product> CreateProduct(Product product)
        {
            product.Id = ProductStore.Products.Max(p => p.Id) + 1;

            ProductStore.Products.Add(product);

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]

        public IActionResult UpdateProduct(int id, Product updatedProduct)
        {
            var existingProduct = ProductStore.Products.FirstOrDefault(p => p.Id == id);

            if (existingProduct is null)
                return NotFound();

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;

            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteProduct(int id)
        {
            var product = ProductStore.Products.FirstOrDefault(p => p.Id == id);

            if (product is null)
                return NotFound();

            ProductStore.Products.Remove(product);

            return NoContent();
        }

        [HttpGet("filter")]

        public ActionResult<List<Product>> FilterProducts(decimal price)
        {
            var  = ProductStore.Products
                .Where(p => p.Price <= price)
                .OrderBy(p => p.Price)
                .ToList();

            return Ok(filteredProducts);
        }

    }
}

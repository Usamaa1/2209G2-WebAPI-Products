using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ProductsContext _context;

        public ProductsController(ProductsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {

            return Ok(_context.Products.ToList());
        }
        [HttpPost]
        public IActionResult AddProducts(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return StatusCode(201);
            }
            catch(Exception)
            {
                return StatusCode(404);
            }
            
        }
        [HttpDelete]
        public IActionResult DeleteProducts(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return StatusCode(201);
        }

    }
}

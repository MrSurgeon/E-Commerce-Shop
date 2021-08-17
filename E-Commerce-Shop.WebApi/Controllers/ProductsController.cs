using Microsoft.AspNetCore.Mvc;
using E_Commerce_Shop.Business.Abstract;

namespace E_Commerce_Shop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetAll();
            if (products == null) return NotFound();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetById(id);
            return product == null ? (IActionResult) NotFound() : Ok(product);
        }

    }
}

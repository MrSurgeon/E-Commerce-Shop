using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_Commerce_Shop.Business.Abstract;
using E_Commerce_Shop.Entity;
using E_Commerce_Shop.WebApi.Dtos;

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
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllAsync();
            if (products == null) return NotFound();

            var productsDto = products.Select(i => new ProductDto()
            {
                ProductId = i.ProductId,
                Name = i.Name,
                Url = i.Url,
                Price = i.Price,
                Description = i.Description,
                ImageUrl = i.ImageUrl

            }).ToList();
            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return product == null ? (IActionResult)NotFound() : Ok(new ProductDto()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Url = product.Url,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl

            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await _productService.CreateAsync(product);
            return CreatedAtAction(nameof(GetProduct), new
            {
                id = product.ProductId
            }, new ProductDto()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Url = product.Url,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl

            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product updated)
        {
            if (id != updated.ProductId)
            {
                return BadRequest();
            }
            var current = await _productService.GetByIdAsync(id);
            if (current == null)
            {
                return NotFound();
            }
            await _productService.UpdateAsync(current, updated);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var p = await _productService.GetByIdAsync(id);
            if (p == null)
            {
                return NotFound();
            }

            await _productService.DeleteAsync(p);
            return NoContent();
        }
    }


}

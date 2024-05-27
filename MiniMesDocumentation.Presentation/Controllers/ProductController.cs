using Microsoft.AspNetCore.Mvc;
using MiniMesDocumentation.Application.Contracts;
using MiniMesDocumentation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMesDocumentation.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Get All Products
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return Ok(products);
        }

        // Create Product
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<ProductEntity>> CreateProduct(ProductEntity product)
        {
            var createdProduct = await _productRepository.CreateProduct(product);
            return CreatedAtAction(nameof(CreateProduct), new { id = createdProduct.Id }, createdProduct);
        }

        // Update Product
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<ActionResult<ProductEntity>> UpdateProduct(int id, ProductEntity updatedProduct)
        {
            var product = await _productRepository.UpdateProduct(id, updatedProduct);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // Delete Product
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productRepository.DeleteProduct(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Get Bottom Products
        [HttpGet]
        [Route("GetBottom/{count}")]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> GetBottomProducts(int count)
        {
            var products = await _productRepository.GetBottomProducts(count);
            return Ok(products);
        }

        // Get Top Products
        [HttpGet]
        [Route("GetTop/{count}")]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> GetTopProducts(int count)
        {
            var products = await _productRepository.GetTopProducts(count);
            return Ok(products);
        }
    }

}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsResourceServer.Model.Product;
using ProductsResourceServer.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace ProductsResourceServer.Controllers
{
    [Route("api/[controller]")]
    //TODO deze naam veranderen
    //[Authorize("dataEventRecordsPolicy")]
    //[Authorize(Roles = "admin")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository ProductRepository;
        public ProductController(IProductRepository _ProductRepository)
        {
            ProductRepository = _ProductRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var Products = await ProductRepository.GetAllProducts();
                return Ok(Products);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}", Name = "ProductById")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var deal = await ProductRepository.GetProduct(id);
                if (deal == null)
                {
                    return NotFound();
                }
                return Ok(deal);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto Product)
        {
            try
            {
                var createdProduct = await ProductRepository.createProduct(Product);
                return CreatedAtRoute("DealById", new { id = createdProduct.Id }, createdProduct);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto Product)
        {
            try
            {
                var dbProduct = await ProductRepository.GetProduct(id);
                if (dbProduct == null)
                    return NotFound();
                await ProductRepository.UpdateProduct(id, Product);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var dbProduct = await ProductRepository.GetProduct(id);
                if (dbProduct == null)
                    return NotFound();
                await ProductRepository.DeleteProduct(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}

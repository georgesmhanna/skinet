using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductType> _productTypesRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandsRepo;

        public ProductsController(IGenericRepository<Product> productsRepo,
                                  IGenericRepository<ProductType> productTypesRepo,
                                  IGenericRepository<ProductBrand> productBrandsRepo)
        {
            _productsRepo = productsRepo;
            _productTypesRepo = productTypesRepo;
            _productBrandsRepo = productBrandsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productsRepo.ListAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return Ok(await _productsRepo.GetByIdAsync(id));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandsRepo.ListAllAsync());
        }
        
        [HttpGet("brands/{id}")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrandById(int id)
        {
            return Ok(await _productBrandsRepo.GetByIdAsync(id));
        }

        [HttpGet("types/{id}")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypeById(int id)
        {
            return Ok(await _productTypesRepo.GetByIdAsync(id));
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypesRepo.ListAllAsync());
        }
    }
}
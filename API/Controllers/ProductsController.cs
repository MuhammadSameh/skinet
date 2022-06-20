using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }


        [HttpGet("getproducts")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            
            var products = await _repo.GetProductsAsync();

            return Ok(products);
        }
        
        [HttpGet("getproduct/{num}")]
        public async Task<Product> GetProduct(int num)
        {
            return await _repo.GetProductByIdAsync(num);
        }

        [HttpGet("getbrands")]
        public async Task<ActionResult<List<ProductBrand>>> GetBrands()
        {

            var brands = await _repo.GetBrandsAsync();

            return Ok(brands);
        }
        
        [HttpGet("gettypes")]
        public async Task<ActionResult<List<ProductType>>> GetTypes()
        {

            var types = await _repo.GetTypesAsync();

            return Ok(types);
        }
    }
}

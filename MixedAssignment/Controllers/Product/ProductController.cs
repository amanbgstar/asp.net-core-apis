using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MixedAssignment.Repository.ProductRepo;
using MixedAssignment.Service.ProductService;
using MixedAssignment.ViewModel.ProductVM;

namespace MixedAssignment.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //Get products by userId
        [HttpGet("{userid}")]
        [Authorize]
        public async Task<IActionResult> GetProductsbyUserid(int userid)
        {
            var list = _productService.GetAllProducts();

            return Ok(list);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GatAllProducts()
        {
            var list = _productService.GetAllProducts();

            return Ok(list);
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var list = _productService.GetProductsByuserId(id);

            return Ok(list);
        }

        // Add product 
        [HttpPost]
        [Authorize]
        public IActionResult AddProduct([FromBody] ProductsVM product)
        {
            var addedProduct = _productService.AddProduct(product);
            if (addedProduct == null)
            {
                return BadRequest("Make sure UserID");
            }

            return Ok(addedProduct);
        }

        // Update Product by ID
        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public IActionResult UpdateProduct(int id, [FromBody] ProductsVM product)
        {
            var productData = _productService.UpdateProduct(id, product);
            if (productData != null)
            {
                return Ok(productData);
            }

            return BadRequest("Someting went wrong");
        }

        // DELETE Product by Id
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public IActionResult Delete(int id)
        {

            var result = _productService.DeleteProduct(id);
            if (result == 0)
            {
                return BadRequest("No Product Found");
            }

            return Ok($"Product Id {id}, product Deleted! ");
        }
    }
}

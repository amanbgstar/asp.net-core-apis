
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MixedAssignment.Domain.Models.Response;
using MixedAssignment.Service.CartService;
using MixedAssignment.Service.ProductService;

namespace MixedAssignment.Controllers.Cart
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        public CartController(ICartService cartService, IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
        }


        //add product to cart table 
        [HttpGet("userid")]
        [Authorize]
        public IActionResult AddProductToCart(int userid, int productid, int qty )
        {
            var response = new CartResponce();
            var returnData = _cartService.AddProductToCart(userid, productid, qty);
            //0 means quantities are not sufficient
            if(returnData == 0)
            {
                var product = _productService.GetProductById(productid);
                response.Stock = product.Stock;
                response.StatusCode = 51;
                return Ok(response);
            }
            response.CartId = returnData;
            response.StatusCode = 200;
            return Ok(response);
        }
    }
}

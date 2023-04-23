using MixedAssignment.Domain.Models;
using MixedAssignment.Repository.CartRepo;
using MixedAssignment.Repository.ProductRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Service.CartService
{
    public class CartService: ICartService
    {
        private readonly ICartRepo _cartRepo;
        private readonly IProductRepo _productRepo;
        public CartService(ICartRepo cartRepo, IProductRepo productRepo)
        {
            _cartRepo = cartRepo;
            _productRepo = productRepo;
        }

        public Cart CartByUserId(int userid)
        {
            return _cartRepo.Cartbyuserid(userid);
        }

        public int AddProductToCart(int userid, int productid, int qty)
        {
            var product = _productRepo.GetProductbyId(productid);
            if (product.Stock < qty)
            {
                return 0;
            }
            var cart = CartByUserId(userid);


            if (cart == null)
            {
                var cartData = new Cart()
                {
                    UserId = userid
                };
                _cartRepo.AddProductToCart(cartData);
            }
            cart = _cartRepo.Cartbyuserid(userid);

            var cartDet = new CartDetail()
            {
                CartId = cart.Id,
                ProductId = productid,
                Quantity = qty
            };
            _cartRepo.AddCartDetails(cartDet);

            return cart.Id;
        }
    }
}

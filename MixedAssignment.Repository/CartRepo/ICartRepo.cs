using MixedAssignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Repository.CartRepo
{
    public interface ICartRepo
    {
        Cart Cartbyuserid(int userid);
        void AddProductToCart(Cart cart);
        void AddCartDetails(CartDetail card);
        List<CartDetail> GetCarDetbyCartId(int cartid);
    }
}

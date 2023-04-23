using MixedAssignment.Domain.Context;
using MixedAssignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Repository.CartRepo
{
    public class CartRepo: ICartRepo
    {
        private readonly UserContext _context;
        public CartRepo(UserContext context)
        {
            _context = context;
        }

        public Cart Cartbyuserid(int userid)
        {
            return _context.Carts.FirstOrDefault(x => x.UserId == userid);
        }
        

        public void AddProductToCart(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
        }

        public void AddCartDetails(CartDetail card)
        {
            _context.CartDetails.Add(card);
            _context.SaveChanges();

        }

        public List<CartDetail> GetCarDetbyCartId(int cartid)
        {
            return _context.CartDetails.Where(x => x.CartId == cartid).ToList();
        }
    }
}

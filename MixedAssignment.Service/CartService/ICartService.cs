using MixedAssignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Service.CartService
{
    public interface ICartService
    {
        Cart CartByUserId(int userid);
        int AddProductToCart(int userid, int productid, int qty);
    }
}

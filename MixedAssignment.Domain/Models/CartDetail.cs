using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Domain.Models
{
    public class CartDetail
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart? Cart { get; set; }
        public int ProductId { get; set; }
       /* public Product? Products { get; set; }*/
        public int Quantity { get; set; }
    }
}

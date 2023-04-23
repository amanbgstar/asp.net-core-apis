using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.ViewModel.ProductVM
{
    public class ProductsVM
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string? ProductImage { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public float SellingPrice { get; set; }
        public float PurchasePrice { get; set; }
        public DateTime SellingDate { get; set; }
        public int Stock { get; set; }
        public int UserId { get; set; }
    }
}

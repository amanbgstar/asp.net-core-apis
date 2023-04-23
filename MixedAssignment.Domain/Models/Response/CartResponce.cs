using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Domain.Models.Response
{
    public class CartResponce
    {
        public int Stock { get; set; }
        public int CartId { get; set; }
        public int StatusCode { get; set; }
    }
}

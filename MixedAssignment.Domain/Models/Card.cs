using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Domain.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public long CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CVV { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}

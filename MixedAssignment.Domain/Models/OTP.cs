using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Domain.Models
{
    public class OTP
    {
        public int Id { get; set; }
        public string Otp { get; set; }
        public DateTime GenDateTime { get; set; }
        public DateTime ValidDateTime { get; set; }
        public int Userid { get; set; }
    }
}

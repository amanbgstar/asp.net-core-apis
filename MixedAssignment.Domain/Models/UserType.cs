using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Domain.Models
{
    public class UserType
    {
        public int UserTypeId { get; set; }
        public string Role { get; set; }
        public List<User>? User { get; set; }
    }
}

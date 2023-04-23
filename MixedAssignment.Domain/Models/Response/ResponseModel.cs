using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Domain.Models.Response
{
    public class ResponseModel
    {
        public string Response { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}

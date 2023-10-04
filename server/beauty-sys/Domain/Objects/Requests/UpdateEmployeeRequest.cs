using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Objects.Requests
{
    public class UpdateEmployeeRequest
    {
        public string? Name { get; set; }
        public string? Office { get; set; }
    }
}

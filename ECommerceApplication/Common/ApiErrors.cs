using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Common
{
    public class ApiErrors
    {
        public string Description { get; set; }

        public ApiErrors(string description)
        {
            Description = description;
        }
    }
}

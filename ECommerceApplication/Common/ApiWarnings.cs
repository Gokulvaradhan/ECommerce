using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Common
{
    public class ApiWarnings
    {
        public string Description { get; set; }

        public ApiWarnings(string description)
        {
            Description = description;
        }
    }
}

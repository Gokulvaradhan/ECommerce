using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDomain.Model
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }

        public int CategoryId { get; set; }

        public string SubCategoryName { get; set; }

        public Category category { get; set; }
    }
}

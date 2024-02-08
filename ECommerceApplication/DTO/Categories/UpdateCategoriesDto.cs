using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.DTO.Categories
{
    public class UpdateCategoriesDto
    {
        public int Id { get; set; } 

        public int CategoryId { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        [Column("Decimal(18,2)")]
        public decimal OldPrice { get; set; }

        [Column("Decimal(18,2)")]
        public decimal NewPrice { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDomain.Model
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string ProductName { get; set; }

        public string ProductImageUrl { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal OldPrice{ get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal NewPrice { get; set; }

        public Category category { get; set; }  

    }
}

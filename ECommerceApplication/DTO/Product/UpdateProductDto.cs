using ECommerceDomain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.DTO.MenClothing
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }   
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public string ProductName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ActualPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public ClothingSize Size { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }

        
        public decimal Total { get; set; }
        public string Description { get; set; }
        public string Reviews { get; set; }
    }

}

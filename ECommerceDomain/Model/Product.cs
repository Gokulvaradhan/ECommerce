using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDomain.Model
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryID { get; set; }

        [ForeignKey("SubCategoryId")]
        public int SubCategoryID { get; set; }
        public string ProductName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ActualPrice { get; set; }

        public ClothingSize Size { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public int Quantity { get; set; }

        public string ProductImageUrl { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }


        public string Description { get; set; }
        public string Reviews { get; set; }


        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }





        public void CalculateTotal()
        {
           
            Total = Quantity * ActualPrice * (1 - Discount); 
        }
    }


        public enum ClothingSize
        {
            S,
            M,
            L,
            XL
        }



}

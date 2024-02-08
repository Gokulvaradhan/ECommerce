using ECommerceDomain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDomain.CartItem
{
    public class AddToCart
    {
        [Key]
        public int CartItemId { get; set; }
        public string ProductImageURL { get; set; }
        public string ProductName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal NewPrice { get; set; }  
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total => NewPrice * Quantity;

        public Categories Categories { get; set; }
    }
}

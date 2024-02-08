using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.DTO.MenClothingType
{
    public class UpdateSubCategoryDto
    {
        public int SubCategoryId { get; set; }

        public int CategoryId { get; set; }

        public string Category { get; set; }

        public string SubCategoryName { get; set; }

     
    }
}

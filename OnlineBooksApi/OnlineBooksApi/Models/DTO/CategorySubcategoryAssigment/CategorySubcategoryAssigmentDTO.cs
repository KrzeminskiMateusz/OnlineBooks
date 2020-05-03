using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.DTO.CategorySubcategoryAssigment
{
    public class CategorySubcategoryAssigmentDTO
    {
        public OnlyCategoryDTO Category { get; set; }
        public OnlySubcategoryDTO Subcategory { get; set; }
    }
}

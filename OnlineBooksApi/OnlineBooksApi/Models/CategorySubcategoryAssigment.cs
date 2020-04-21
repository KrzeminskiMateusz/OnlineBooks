using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models
{
    public class CategorySubcategoryAssigment
    {
        public int SubcategoryId { get; set; }
        public int CategoryId { get; set; }
        public Subcategory Subcategory { get; set; }
        public Category Category { get; set; }
    }
}

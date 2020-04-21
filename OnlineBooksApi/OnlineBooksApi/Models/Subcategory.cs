using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string SubcategoryName { get; set; }
#nullable enable
        public IEnumerable<CategorySubcategoryAssigment>? Categories { get; set; }
#nullable disable
    }
}

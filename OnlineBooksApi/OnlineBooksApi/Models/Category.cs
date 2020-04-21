using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models
{
    public class Category
    {
        // Znaleźć atrybut sprawdzający unikalność categoryName w bazie
        public int Id { get; set; }
        public string CategoryName { get; set; }

#nullable enable
        public IEnumerable<BookCategoryAssigment>? Books { get; set; }
        public IEnumerable<AuthorCategoryAssigment>? Authors { get; set; }
        public IEnumerable<CategorySubcategoryAssigment>? Subcategories { get; set; }
#nullable disable
    }
}

using OnlineBooksApi.Models.DTO.Author;
using OnlineBooksApi.Models.DTO.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.DTO.Category
{
    public class CategoryDTO
    {
        public string Name { get; set; }

#nullable enable
        public IEnumerable<SubcategoryAssigmentDTO>? Subcategories { get; set; }

        public IEnumerable<CategoryBookAssigmentDTO>? Books { get; set; }

        public IEnumerable<CategoryAuthorAssigmentDTO>? Authors { get; set; }
#nullable disable
    }
}

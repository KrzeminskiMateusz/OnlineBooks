using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models
{
    public class Subcategory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
#nullable enable
        public IEnumerable<CategorySubcategoryAssigment>? Categories { get; set; }

        public IEnumerable<AuthorSubcategoryAssigment>? Authors { get; set; }

        public IEnumerable<BookSubcategoryAssigment>? Books { get; set; }
#nullable disable
    }
}

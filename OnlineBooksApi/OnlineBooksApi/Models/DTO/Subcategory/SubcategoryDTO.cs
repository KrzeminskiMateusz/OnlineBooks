using OnlineBooksApi.Models.DTO.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.DTO.Subcategory
{
    public class SubcategoryDTO
    {
        public string Name { get; set; }
#nullable enable
        public IEnumerable<CategoryAssigmentDTO>? Categories { get; set; }

        public IEnumerable<SubcategoryAuthorAssigmentDTO>? Authors { get; set; }

        public IEnumerable<SubcategoryBookAssigmentDTO>? Books { get; set; }
#nullable disable
    }
}

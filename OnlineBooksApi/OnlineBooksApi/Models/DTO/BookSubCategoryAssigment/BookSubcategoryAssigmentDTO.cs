using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.DTO.BookSubCategoryAssigment
{
    public class BookSubcategoryAssigmentDTO
    {
        public OnlySubcategoryDTO Subcategory { get; set; }

        public BookAssigmentDTO Book { get; set; }
    }
}

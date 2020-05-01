using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.DTO.BookCategoryAssigment
{
    public class BookCategoryAssigmentDTO
    {
        public OnlyCategoryDTO Category { get; set; }

        public BookAssigmentDTO Book { get; set; }
    }
}

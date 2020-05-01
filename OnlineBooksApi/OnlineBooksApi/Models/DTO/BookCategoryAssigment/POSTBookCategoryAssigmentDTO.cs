using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.DTO.BookCategoryAssigment
{
    public class POSTBookCategoryAssigmentDTO
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }
    }
}

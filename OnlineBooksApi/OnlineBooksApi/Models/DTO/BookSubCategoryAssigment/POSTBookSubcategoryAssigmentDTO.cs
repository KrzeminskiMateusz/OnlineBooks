using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.DTO.BookSubCategoryAssigment
{
    public class POSTBookSubcategoryAssigmentDTO
    {
        public int BookId { get; set; }
        public int SubcategoryId { get; set; }
    }
}

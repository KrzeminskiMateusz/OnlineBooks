using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.DTO.AuthorSubcategoryAssigment
{
    public class POSTAuthorSubcategoryAssigmentDTO
    {
        public int AuthorId { get; set; }
        public int SubcategoryId { get; set; }
    }
}

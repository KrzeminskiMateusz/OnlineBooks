using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.DTO.AuthorSubcategoryAssigment
{
    public class AuthorSubcategoryAssigmentDTO
    {
        public OnlySubcategoryDTO Subcategory { get; set; }

        public AuthorAssigmentDTO Author { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.DTO.AuthorCategoryAssigment
{
    public class AuthorCategoryAssigmentDTO
    {
        public OnlyCategoryDTO Category { get; set; }

        public AuthorAssigmentDTO Author { get; set; }
    }
}

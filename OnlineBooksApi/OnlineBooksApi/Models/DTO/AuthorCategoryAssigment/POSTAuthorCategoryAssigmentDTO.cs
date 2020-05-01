using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.DTO.AuthorCategoryAssigment
{
    public class POSTAuthorCategoryAssigmentDTO
    {
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}

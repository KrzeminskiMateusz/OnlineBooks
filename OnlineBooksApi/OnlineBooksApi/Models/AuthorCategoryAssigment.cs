using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models
{
    public class AuthorCategoryAssigment
    {
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }

        public Author Author { get; set; }
        public Category Category { get; set; }
    }
}

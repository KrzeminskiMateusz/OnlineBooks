using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models
{
    public class AuthorSubcategoryAssigment
    {
        public int AuthorId { get; set; }

        public int SubcategoryId { get; set; }

        public Author Author { get; set; }

        public Subcategory Subcategory { get; set; }
    }
}

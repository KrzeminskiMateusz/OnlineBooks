using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models
{
    public class BookSubcategoryAssigment
    {
        public int BookId { get; set; }

        public int SubcategoryId { get; set; }

        public Book Book { get; set; }

        public Subcategory Subcategory { get; set; }
    }
}

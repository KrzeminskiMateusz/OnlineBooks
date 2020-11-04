using OnlineBooksApi.Models.DTO.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.DTO.Book
{
    public class BookDTO
    {
#nullable enable
        public long Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public byte[]? Cover { get; set; }

        public DateTime PublcationDate { get; set; }

        public int? NumberOfPages { get; set; }

        public BookAuthorDTO? Author { get; set; }

        public IEnumerable<CategoryAssigmentDTO>? Categories { get; set; }

        public IEnumerable<SubcategoryAssigmentDTO>? Subcategories { get; set; }

        public IEnumerable<ShelftAssigmentDTO>? Shelves { get; set; }

#nullable disable
    }
}

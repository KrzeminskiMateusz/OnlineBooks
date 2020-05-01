using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.DTO
{
    public class BookAssigmentDTO
    {
#nullable enable
        public string? Title { get; set; }

        public string? Description { get; set; }

        public byte[]? Cover { get; set; }

        public DateTime PublcationDate { get; set; }

        public int? NumberOfPages { get; set; }
#nullable disable
    }
}

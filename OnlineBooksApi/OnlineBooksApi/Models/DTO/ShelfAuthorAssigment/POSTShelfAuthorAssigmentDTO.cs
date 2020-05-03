using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.DTO.ShelfAuthorAssigment
{
    public class POSTShelfAuthorAssigmentDTO
    {
        public int ShelfId { get; set; }
        public int AuthorId { get; set; }
    }
}

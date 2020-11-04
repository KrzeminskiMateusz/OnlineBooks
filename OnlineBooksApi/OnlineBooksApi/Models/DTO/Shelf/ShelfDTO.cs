using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.DTO.Shelf
{
    public class ShelfDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsAvelibleForAuthor { get; set; }

        public bool IsAvelibleForBook { get; set; }

#nullable enable
        public IEnumerable<ShelfBookAssigmentDTO>? Books { get; set; }
        public IEnumerable<ShelfAuthorAssigmentDTO>? Authors { get; set; }
#nullable disable
    }
}

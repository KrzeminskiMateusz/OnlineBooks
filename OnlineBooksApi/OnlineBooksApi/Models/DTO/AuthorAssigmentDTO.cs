using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.DTO
{
    public class AuthorAssigmentDTO
    {
#nullable enable
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Nationality { get; set; }

        public DateTime? DataOfBirth { get; set; }

        public string? PlaceOfBirth { get; set; }

        public string? CountryOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public string? PlaceOfDeath { get; set; }

        public string? CountryOfDeath { get; set; }

        public string? Description { get; set; }

        public byte[]? Image { get; set; }

        public bool? IsAlive { get; set; }
#nullable disable
    }
}

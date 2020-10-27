using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBooksDesktopApp.Model
{
    public class Author
    {
        public string? firstName { get; set; }

        public string? lastName { get; set; }

        public string? nationality { get; set; }

        public DateTime? dataOfBirth { get; set; }

        public string? placeOfBirth { get; set; }

        public string? countryOfBirth { get; set; }

        public DateTime? dateOfDeath { get; set; }

        public string? placeOfDeath { get; set; }

        public string? countryOfDeath { get; set; }

        public string? description { get; set; }

        public byte[]? image { get; set; }

        public bool? isAlive { get; set; }
    }
}

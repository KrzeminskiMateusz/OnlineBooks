using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public string Nationality { get; set; }

        public DateTime DataOfBirth { get; set; }
#nullable enable
        public IEnumerable<Book>? Books { get; set; }
        public IEnumerable<AuthorCategoryAssigment>? Categories { get; set; }
        public IEnumerable<ShelftAuthorAssigment>? Shelves { get; set; }
#nullable disable
    }
}

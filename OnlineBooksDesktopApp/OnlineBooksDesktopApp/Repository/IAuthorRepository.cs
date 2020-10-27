using OnlineBooksDesktopApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooksDesktopApp.Repository
{
    public interface IAuthorRepository
    {
        Task<Author> GetAuthor(long id);
        Task<List<Author>> GetAuthors();
        Task<bool> CreateAuthor(Author author);
        Task<bool> DeleteAuthor(long authorId);
        Task<bool> UpdateAuthor(Author author);
    }
}

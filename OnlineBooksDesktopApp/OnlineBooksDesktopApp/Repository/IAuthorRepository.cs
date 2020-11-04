using OnlineBooksDesktopApp.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooksDesktopApp.Repository
{
    public interface IAuthorRepository
    {
        Task<Author> GetAuthor(long id);
        Task<List<Author>> GetAuthors();
        Task<HttpResponseMessage> CreateAuthor(Author author);
        Task<HttpResponseMessage> DeleteAuthor(long authorId);
        Task<HttpResponseMessage> UpdateAuthor(Author author);
    }
}

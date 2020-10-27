using OnlineBooksDesktopApp.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineBooksDesktopApp.Repository
{
    class AuthorAPI : IAuthorRepository
    {
        public Task<Author> GetAuthor(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Author>> GetAuthors()
        {
            WebClient webClient = new WebClient();
            string responseBody = webClient.DownloadString("https://localhost:44348/api/Authors");

            List<Author> authors = JsonSerializer.Deserialize<List<Author>>(responseBody);

            return await Task.FromResult(authors);
        }

        public Task<bool> CreateAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAuthor(long authorId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}

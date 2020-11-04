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
        public async Task<Author> GetAuthor(long authorId)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetStreamAsync("https://localhost:44348/api/Authors/" + authorId);

                return await JsonSerializer.DeserializeAsync<Author>(await result);
            }         
        }

        public async Task<List<Author>> GetAuthors()
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetStreamAsync("https://localhost:44348/api/Authors");

                return await JsonSerializer.DeserializeAsync<List<Author>>(await result);
            }
        }

        public async Task<HttpResponseMessage> CreateAuthor(Author author)
        {
            var authorJSON = JsonSerializer.Serialize(author);
            var httpContent = new StringContent(authorJSON, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {               
                return await client.PostAsync("https://localhost:44348/api/Authors", httpContent);
            }
        }

        public async Task<HttpResponseMessage> UpdateAuthor(Author author)
        {
            var authorJSON = JsonSerializer.Serialize(author);
            var httpContent = new StringContent(authorJSON, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                return await client.PutAsync("https://localhost:44348/api/Authors/" + author.Id, httpContent);
            }
        }

        public async Task<HttpResponseMessage> DeleteAuthor(long authorId)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.DeleteAsync("https://localhost:44348/api/Authors/" + authorId);
            }
        }
    }
}

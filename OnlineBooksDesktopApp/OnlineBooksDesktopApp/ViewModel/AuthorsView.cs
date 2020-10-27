using OnlineBooksDesktopApp.Model;
using OnlineBooksDesktopApp.Repository;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

namespace OnlineBooksDesktopApp.ViewModel
{
    public class AuthorsView
    {
        private readonly IAuthorRepository _authorRepository;
        public List<Author> Authors { get; set; }

        public AuthorsView(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
            //Authors =  _authorRepository.GetAuthors().Result;
        }    
    }
}

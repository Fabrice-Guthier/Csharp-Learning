using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace tpPOO_1302
{
    public class Book
    {        
        public Book()
        {
            Title = "";
            Author = "";
            Genre = BookGenre.Default;
            Database.Books.Add(this);
        }

        public Book(string initTitle, string initAuthor)
        {
            Title = initTitle;
            Author = initAuthor;
        }

        public Book(string initTitle, string initAuthor, BookGenre initGenre)
        {
            Title = initTitle;
            Author = initAuthor;
            Genre = initGenre;
            
        }


        public string Title { get; set; }
        public string Author { get; set; }
        public BookGenre Genre { get; set; }

       

        public void AddBookInDatabase()
        {
            Database.AddBook(this);
        }

    }
}

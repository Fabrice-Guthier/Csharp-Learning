using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace tpPOO_1302
{
    public class Database
    {
        public static List<Book> books = new List<Book>();

        public List<Book> books { get; set; }

        static Database()
        {
            books.Add(new Book("Harry Potter", "J.K. Rowling", BookGenre.Youth));
            books.Add(new Book("Le Seigneur des Anneaux", "J.R.R. Tolkien", BookGenre.Fantasy));
            books.Add(new Book("Le Petit Prince", "Antoine de Saint-Exupéry", BookGenre.Novel));
            books.Add(new Book("1984", "George Orwell", BookGenre.SciFi));
            books.Add(new Book("Le Rouge et le Noir", "Stendhal", BookGenre.Thriller));
        }

        public static void DisplayBooks()
        {
            Console.WriteLine("Voici la liste des livres de la bibliothèque : ");
            foreach (var book in books)
            {
                Console.WriteLine(book.Title + " de " + book.Author + " , dont le genre est : " + book.Genre);
            }
        }

        public static void AddBook(Book book)
        {
            books.Add(book);
        }   
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace tpPOO_1302
{
    public class Program
    {
        static void Main(string[] args)
        {
            Database.DisplayBooks();
            Console.WriteLine();
            Book book1 = new Book("Dune", "Frank Herbert", BookGenre.SciFi);
            Book book2 = new Book("Berserk", "Kentaro Miura", BookGenre.Manga);

            User user1 = new User("Fabrice", "Guthier", "fabrice.guthier@gmail.com");

            book1.AddBookInDatabase();
            book2.AddBookInDatabase();

            user1.BorrowedBooks.add(book1);
            user1.BorrowedBooks.add(book2);

            Database.DisplayBooks();

            Console.ReadLine();
        }
    }
}
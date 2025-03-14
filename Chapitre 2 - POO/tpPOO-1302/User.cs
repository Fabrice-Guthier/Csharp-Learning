using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace tpPOO_1302
{
	public class User
	{
        public User()
        {
            FirstName = "unnamed";
            LastName = "unnamed";
            Email = "test@test.com";
            BorrowedBooks = new List<Book>();
        }

        public User(string initFirstName, string initLastName, string initEmail, List<Book> initborrowedBooks)
        {
            FirstName = initFirstName;
            LastName = initLastName;
            Email = initEmail;
            BorrowedBooks = initborrowedBooks;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public void DisplayBorrowedBooks()
        {
            foreach (Book book in BorrowedBooks)
            {
                book.Title;
            }
        }
    }
}

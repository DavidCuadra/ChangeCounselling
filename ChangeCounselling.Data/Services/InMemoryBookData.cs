using ChangeCounselling.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCounselling.Data.Services
{

    public class InMemoryBookData : IBookData
    {
        List<Book> books;
        public InMemoryBookData()
        {
            //books = new List<Book>()
            //    {
            //        new Book {BookID = 1, ClientID = 1, CounsellorID = 1, DateTime = 1/1/2001 12:00:00 AM , Booked = true},
            //        new Book {BookID = 2, ClientID = 2, CounsellorID  = 2, DateTime = 15/2/2011 20:00:00 AM , Booked = false},
            //        new Book {BookID = 3, ClientID = 3, CounsellorID  = 3, DateTime = 20/3/2031 18:00:00 AM , Booked = true},
            //    };
        }

        public void Add(Book book)

        {
            books.Add(book);
            book.BookID = books.Max(c => c.BookID) + 1;
        }


        public void Update(Book book)
        {
            var existing = Get(book.BookID);
            if (existing != null)
            {
                existing.BookID = book.BookID;
                existing.ClientID = book.ClientID;
                existing.CounsellorID = book.CounsellorID;
                existing.DateTime = book.DateTime;
            }
        }

        public Book Get(int id)
        {
            return books.FirstOrDefault(c => c.BookID == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return books.OrderBy(c => c.BookID);
        }
        public void Delete(int id)
        {
            var book = Get(id);
            if (book != null)
            {
                books.Remove(book);
            }
        }




    }
}

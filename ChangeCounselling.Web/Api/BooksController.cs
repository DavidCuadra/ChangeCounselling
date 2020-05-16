using ChangeCounselling.Data.Models;
using ChangeCounselling.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ChangeCounselling.Web.Api
{
    public class BooksController : ApiController
    {
        private readonly IBookData db;

        public BooksController(IBookData db)
        {
            this.db = db;
        }

        public IEnumerable<Book> Get()
        {
            var result = db.GetAll().ToList();


            List<Book> books = new List<Book>();
            foreach(var item in result)
            {
                books.Add(new Book {
                    BookID=item.BookID,
                    CounsellorID=item.CounsellorID,
                    ClientID=item.ClientID,
                    DateTime=item.DateTime
                });
            }

            return books;


        }
    }
}
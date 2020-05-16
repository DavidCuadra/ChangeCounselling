using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeCounselling.Data.Models;

namespace ChangeCounselling.Data.Services
{
    public class SqlBookData : IBookData
    {

        private readonly CounsellorDbContext db;

        public SqlBookData(CounsellorDbContext db)
        {
            this.db = db;
        }

        public void Add(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
        }

        public Book Get(int id)
        {
            return db.Books.FirstOrDefault(b => b.BookID == id);
        }

        public IEnumerable<Book> GetAll()
        {
           return  from b in db.Books
                   orderby b.BookID
                   select b;

        }
        public IEnumerable<Book> GetAllWithClientCounsellor()
        {
            var result = db.Books
                .Include(p => p.Client)
                .Include(p => p.Counsellor)
                .ToList();
            return result;
        }

        public void Update(Book book)
        {
            var entry = db.Entry(book);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}

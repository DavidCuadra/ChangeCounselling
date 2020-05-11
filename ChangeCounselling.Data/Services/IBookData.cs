using ChangeCounselling.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCounselling.Data.Services
{
    public interface IBookData
    {
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetAllWithClientCounsellor();

        Book Get(int id);
        void Add(Book book);
        void Update(Book book);
        void Delete(int id);
    }
}

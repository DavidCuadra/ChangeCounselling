using ChangeCounselling.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCounselling.Data.Services
{
    public interface IBillData
    {
        IEnumerable<Bill> GetAll();

        IEnumerable<Book> GetAllWithClientCounsellor();

        Bill Get(int id);
        void Add(Bill bill);
        void Update(Bill bill);
        void Delete(int id);
    }
}

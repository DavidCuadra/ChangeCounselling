using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeCounselling.Data.Models;

namespace ChangeCounselling.Data.Services
{
    public class SqlBillData: IBillData
    {
        private readonly CounsellorDbContext db;

        public SqlBillData(CounsellorDbContext db)
        {
            this.db = db;
        }

        public void Add(Bill bill)
        {
            db.Bills.Add(bill);
            db.SaveChanges();
        }


        public void Delete(int id)
        {
            var bill = db.Bills.Find(id);
            db.Bills.Remove(bill);
            db.SaveChanges();

        }

        public Bill Get(int id)
        {
            return db.Bills.FirstOrDefault(b => b.BillID == id);
        }

        public IEnumerable<Bill> GetAll()
        {
            return from b in db.Bills
                   orderby b.BillID
                   select b;
        }

        public void Update(Bill bill)
        {
            var entry = db.Entry(bill);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

       
    }
}

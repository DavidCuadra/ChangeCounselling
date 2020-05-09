using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeCounselling.Data.Models;

namespace ChangeCounselling.Data.Services
{
    public class InMemoryBillData : IBillData
    {
        List<Bill> bills;

        public InMemoryBillData()
        {
            //bills = new List<Bill>()
            //{
            //        new Bill {BillID = 1, DateTime = 1/1/2001 12:00:00 AM, ClientEmail = "Cuadra@hotmail.com", CounsellorEmail = "Mcfadden@yahoo.com", BookID = 1},
            //        new Bill {BillID = 2, DateTime = 1/1/2001 12:00:00 AM, ClientEmail = "Mcfadden@yahoo.com", CounsellorEmail = "Cuadra@hotmail.com", BookID = 2},
            //        new Bill {BillID = 3, DateTime = 1/1/2001 12:00:00 AM, ClientEmail = "Cromer@gmail.com", CounsellorEmail = "Cuadra@hotmail.com", BookID = 3}
            //};
        }

        public void Add(Bill bill)
        {
            bills.Add(bill);
            bill.BillID = bills.Max(c => c.BillID) + 1;
        }

        public void Update(Bill bill)
        {
            var existing = Get(bill.BillID);
            if (existing != null)
            {
                existing.BillID = bill.BillID;
                existing.DateTime = bill.DateTime;
                existing.ClientEmail = bill.ClientEmail;
                existing.CounsellorEmail = bill.CounsellorEmail;
                existing.BookID = bill.BookID;

            }
        }

        public Bill Get(int id)
        {
            return bills.FirstOrDefault(b => b.BillID == id);
        }

        public IEnumerable<Bill> GetAll()
        {
            return bills.OrderBy(b => b.BillID);
        }

        public void Delete(int id)
        {
            var bill = Get(id);
            if (bill != null)
            {
                bills.Remove(bill);
            }
        }

        IEnumerable<Bill> IBillData.GetAll()
        {
            throw new NotImplementedException();
        }

       
    }
}

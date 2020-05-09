using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeCounselling.Data.Models;

namespace ChangeCounselling.Data.Services
{
   public class SqlLoginData : ILoginData
    {
        private readonly CounsellorDbContext db;

        public SqlLoginData(CounsellorDbContext db)
        {
            this.db = db;
        }

        public void Add(Login item)
        {
            db.Logins.Add(item);
            db.SaveChanges();
        }

        public bool Auth(Login login)
        {
         var result= db.Logins.
                Where(p => p.Email.Equals(login.Email) && p.Passwd.Equals(login.Passwd))
                .FirstOrDefault();

            if (result != null)
                return true;

            return false;
        }

        public void Delete(int id)
        {
            var item = db.Logins.Find(id);
            db.Logins.Remove(item);
            db.SaveChanges();

        }

        public Login Get(int id)
        {
            return db.Logins.FirstOrDefault(b => b.LoginID == id);
        }

        public IEnumerable<Login> GetAll()
        {
            return db.Logins.OrderBy(o => o.LoginID).ToList();
        }

        public void Update(Login item)
        {
            var entry = db.Entry(item);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}

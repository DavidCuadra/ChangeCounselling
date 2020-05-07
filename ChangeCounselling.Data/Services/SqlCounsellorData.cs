using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeCounselling.Data.Models;

namespace ChangeCounselling.Data.Services
{
    public class SqlCounsellorData : ICounsellorData
    {
        private readonly CounsellorDbContext db;

        public SqlCounsellorData(CounsellorDbContext db)
        {
            this.db = db;
        }

        public void Add(Counsellor counsellor)
        {
            db.Counsellors.Add(counsellor);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var counsellor = db.Counsellors.Find(id);
            db.Counsellors.Remove(counsellor);
            db.SaveChanges();

        }

        public Counsellor Get(int id)
        {
            return db.Counsellors.FirstOrDefault(c => c.CounsellorID == id);
        }

        public IEnumerable<Counsellor> GetAll()
        {
            return from c in db.Counsellors
                   orderby c.CouncellorFirstName
                   select c;
        }

        public void Update(Counsellor counsellor)
        {
            var entry = db.Entry(counsellor);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}

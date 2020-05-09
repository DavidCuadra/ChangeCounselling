using ChangeCounselling.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCounselling.Data.Services
{
   public  class InMemoryLoginData
    {
        private SqlLoginData db;
        public InMemoryLoginData()
        {
            this.db = new SqlLoginData(new CounsellorDbContext());
        }
        public void Insert()
        {
            Login login = new Login();
            login.Email = "mx@mx.mx";
            login.Passwd = "12345";
            db.Add(login);

        }
        public bool Auth()
        {
            var item = new Login
            {
                Email = "mx@mx.mx",
                Passwd = "123456"
            };
            return db.Auth(item);
        }
    }
}

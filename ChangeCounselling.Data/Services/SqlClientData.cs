﻿using ChangeCounselling.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ChangeCounselling.Data.Services
{
    public class SqlClientData:IClientData
    {
        private readonly CounsellorDbContext db;

        public SqlClientData(CounsellorDbContext db)
        {
            this.db = db;
        }

     

        public void Add(Client client)
        {
            db.Clients.Add(client);
            db.SaveChanges();
        }


        public void Delete(int id)
        {
            var client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
        }


        public Client Get(int id)
        {
            return db.Clients.FirstOrDefault(c => c.ClientID == id);

        }

            public IEnumerable<Client> GetAll()
        {
            return from c in db.Clients
                   orderby c.ClientFirstName
                   select c;
        }

        public void Update(Client client)
        {
            var entry = db.Entry(client);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}

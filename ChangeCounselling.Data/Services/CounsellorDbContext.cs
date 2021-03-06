﻿using ChangeCounselling.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCounselling.Data.Services
{
    public class CounsellorDbContext : DbContext
    {
        public DbSet<Counsellor> Counsellors { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Bill> Bills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //avoids pluralization for tabels.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //avoids delete on cascade.
           // modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

    }

    
}

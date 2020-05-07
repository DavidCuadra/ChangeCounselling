using ChangeCounselling.Data.Models;
using ChangeCounselling.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace ChangeCounselling.Web.Api
{
    public class ClientsController : ApiController
    {
        private readonly IClientData db;

        public ClientsController(IClientData db)
        {
            this.db = db;
        }

        public IEnumerable<Client> Get()
        {
            return db.GetAll();


        }
    }
}
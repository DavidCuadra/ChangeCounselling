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
            var result = db.GetAll().ToList();


            List<Client> clients = new List<Client>();
            foreach (var item in result)
            {
                clients.Add(new Client
                {
                    ClientID = item.ClientID,
                    ClientFirstName = item.ClientFirstName,
                    ClientLastName = item.ClientLastName,
                    ClientAddressLine1 = item.ClientAddressLine1,
                    ClientAddressLine2 = item.ClientAddressLine2,
                    ClientAddressLine3 = item.ClientAddressLine3,
                    ClientEmail = item.ClientEmail,
                    ClientPhone = item.ClientPhone

                });
            }

            return clients;


        }
    }
}
using ChangeCounselling.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ChangeCounselling.Data.Services
{
    public interface IClientData
    {
            IEnumerable<Client> GetAll();

            Client Get(int id);
            void Add(Client client);
            void Update(Client client);
            void Delete(int id);
    }
}

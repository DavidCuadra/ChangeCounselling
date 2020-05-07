using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeCounselling.Data.Models;

namespace ChangeCounselling.Data.Services
{
    public class InMemoryClientData : IClientData
    {
        List<Client> clients;
        public InMemoryClientData()
        {
            //clients = new List<Client>()
            //    {
            //        new Client {ClientID = 1, ClientFirstName = "Juan", ClientLastName = "Oldani", ClientAddressLine1 = "26 Basil Road", ClientAddressLine2 = "Swiss", ClientAddressLine3 = "Basil", ClientEmail = "juan@oldani.com", ClientPhone = "55555555"},
            //        new Client {ClientID = 2, ClientFirstName = "Lily", ClientLastName = "Cuadra", ClientAddressLine1 = "76 Venice Road", ClientAddressLine2 = "Cosa Nostra", ClientAddressLine3 = "Italia", ClientEmail = "lily@cuadra.com", ClientPhone = "333333333"},
            //        new Client {ClientID = 3, ClientFirstName = "Pipa", ClientLastName = "Cuadra", ClientAddressLine1 = "6 Anner Road", ClientAddressLine2 = "Kilmainham", ClientAddressLine3 = "Dublin", ClientEmail = "pipa@cuadra.com", ClientPhone = "999999999"},
            //    };
        }

        public void Add(Client client)
        {
            clients.Add(client);
            client.ClientID = clients.Max(c => c.ClientID) + 1;
        }

        public void Update(Client client)
        {
            var existing = Get(client.ClientID);
            if (existing != null)
            {
                existing.ClientID = client.ClientID;
                existing.ClientFirstName = client.ClientFirstName;
                existing.ClientLastName = client.ClientLastName;
                existing.ClientAddressLine1 = client.ClientAddressLine1;
                existing.ClientAddressLine2 = client.ClientAddressLine2;
                existing.ClientAddressLine3 = client.ClientAddressLine3;
                existing.ClientEmail = client.ClientEmail;
                existing.ClientPhone = client.ClientPhone;
            }
        }

        public Client Get(int id)
        {
            return clients.FirstOrDefault(c => c.ClientID == id);
        }

        public IEnumerable<Client> GetAll()
        {
            return clients.OrderBy(c => c.ClientFirstName);
        }
        public void Delete(int id)
        {
            var client = Get(id);
            if (client != null)
            {
                clients.Remove(client);
            }
        }
        
    }
}

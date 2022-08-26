using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Infrastructure.Persistence
{

    public class ClientInMemoryRepository : IClientRepository
    {
        private static readonly Dictionary<Guid, Client> _clients = new();

        public void AddClient(Client client)
        {
            _clients.Add(client.Id, client);
        }

        public Client? GetClientByEmail(string email)
        {
            return _clients.Values
                .FirstOrDefault(x=>x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public Client? GetClientById(Guid id)
        {
            if (!_clients.ContainsKey(id))
                return null;

            return _clients[id];
        }

        public IEnumerable<Client> GetClients()
        {
            return _clients.Values;
        }

        public void RemoveClientByEmail(string email)
        {
            var client = GetClientByEmail(email);

            if (client == null)
                return;

            _clients.Remove(client.Id);

        }

        public void RemoveClientById(Guid id)
        {
            _clients.Remove(id);
        }

        public void UpsertClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}

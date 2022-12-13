using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Domain.ClientAggregate;

namespace AcmeLibrary.Infrastructure.Persistence
{

    public class ClientInMemoryRepository : IClientRepository
    {
        private static readonly Dictionary<Guid, Client> _clients = new();

        public void AddClient(Client client)
        {
            _clients.Add(client.Id.Value, client);
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

            if (client is null)
                return;

            _clients.Remove(client.Id.Value);

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

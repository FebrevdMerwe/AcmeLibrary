using AcmeLibrary.Domain.Entities;

namespace AcmeLibrary.Application.Interfaces.Persistance
{
    public interface IClientRepository
    {
        void AddClient(Client client);

        Client? GetClientByEmail(string email);

        Client? GetClientById(Guid id);

        IEnumerable<Client> GetClients();

        void RemoveClientByEmail(string email);

        void RemoveClientById(Guid id);

        void UpsertClient(Client client);
    }
}
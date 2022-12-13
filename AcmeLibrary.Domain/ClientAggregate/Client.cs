using AcmeLibrary.Domain.ClientAggregate.ValueObjects;
using AcmeLibrary.Domain.Common.Models;
using System.Globalization;

namespace AcmeLibrary.Domain.ClientAggregate
{
    public sealed class Client : AggregateRoot<ClientId>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

        private Client(string firstName, string lastName, string email)
            :base(ClientId.CreateUnique())
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public static Client Create(string firstName, string lastName, string email)
        {
            return new Client(firstName, lastName, email);
        }
    }
}

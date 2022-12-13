namespace AcmeLibrary.Contracts.Clients
{
    public record CreateClientRequest(
        string FirstName,
        string LastName,
        string Email);
}
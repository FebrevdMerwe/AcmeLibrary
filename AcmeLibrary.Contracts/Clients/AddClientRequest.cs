namespace AcmeLibrary.Contracts.Clients
{
    public record AddClientRequest(
        string FirstName,
        string LastName,
        string Email);
}
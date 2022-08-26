namespace AcmeLibrary.Contracts.Clients
{
    public record ClientResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Email);
}
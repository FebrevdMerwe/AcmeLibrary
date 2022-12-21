
namespace AcmeLibrary.Contracts.Sections
{
    public record CreateSectionRequest(
        string Name,
        Guid LibraryId);
}

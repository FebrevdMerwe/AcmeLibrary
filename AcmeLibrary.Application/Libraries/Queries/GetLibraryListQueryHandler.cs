using AcmeLibrary.Application.Books.Common;
using AcmeLibrary.Application.Interfaces.Persistance;
using ErrorOr;
using MediatR;
using AcmeLibrary.Domain.LibraryAggregate;

namespace AcmeLibrary.Application.Libraries.Queries
{
    public class GetLibraryListQueryHandler : IRequestHandler<GetLibraryListQuery, ErrorOr<IEnumerable<Library>>>
    {
        private readonly ILibraryRepository _libraryRepository;

        public GetLibraryListQueryHandler(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository ?? throw new ArgumentNullException(nameof(libraryRepository));
        }

        public async Task<ErrorOr<IEnumerable<Library>>> Handle(GetLibraryListQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var libraries = _libraryRepository
                .GetAll()
                .ToList();

            return libraries;
        }
    }
}
